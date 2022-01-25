using GTA;
using GTA.UI;
using LemonUI.Menus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TuningShops.Core;
using TuningShops.Overrides;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Manages all of the Part specific Cameras.
    /// </summary>
    internal static class CameraManager
    {
        #region Fields

        private static readonly Dictionary<string, Guid> associations = new Dictionary<string, Guid>();
        private static readonly Dictionary<Guid, CameraCore> cameras = new Dictionary<Guid, CameraCore>();

        #endregion

        #region Properties

#if DEBUG
        /// <summary>
        /// The menu used to test the different cameras.
        /// </summary>
        public static NativeMenu DebugMenu { get; } = new NativeMenu("", "Manual Camera Activation")
        {
            Width = 500
        };
#endif

        #endregion

        #region Tools

        private static void PopulateSpecific<T>(string path) where T : CameraCore
        {
            foreach (string file in Directory.EnumerateFiles(path))
            {
                if (!file.ToLowerInvariant().EndsWith(".json"))
                {
                    Notification.Show($"~o~Warning~s~: File {file} is not a JSON File!");
                    continue;
                }

                try
                {
                    string contents = File.ReadAllText(file);

                    T cameraToBone = JsonConvert.DeserializeObject<T>(contents);

                    if (cameras.ContainsKey(cameraToBone.Id))
                    {
                        Notification.Show($"~o~Warning~s~: There is already a Camera with the ID {cameraToBone.Id}!");
                        continue;
                    }

                    cameras.Add(cameraToBone.Id, cameraToBone);

#if DEBUG
                    DebugMenu.Add(new CameraDebugItem(Path.GetFileName(path), cameraToBone));
#endif
                }
                catch (Exception ex)
                {
                    Notification.Show($"~o~Warning~s~: Unable to load {Path.GetFileName(file)}:\n{ex.Message}");
                }
            }
        }
        private static void PopulateAssociations()
        {
            associations.Clear();

            string path = Path.Combine(TuningShops.location, "Cameras", "Association.json");

            try
            {
                string contents = File.ReadAllText(path);
                Dictionary<string, Guid> @new = JsonConvert.DeserializeObject<Dictionary<string, Guid>>(contents);
                foreach (KeyValuePair<string, Guid> pair in @new)
                {
                    associations.Add(pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                Notification.Show($"~o~Warning~s~: Unable to load Camera Associations:\n{ex.Message}");
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Loads the Cameras from Hard Drive.
        /// </summary>
        public static void Populate()
        {
            cameras.Clear();
#if DEBUG
            DebugMenu.Clear();
#endif
            GeneralCamera general = new GeneralCamera();
            cameras.Add(Guid.Empty, general);
#if DEBUG
            DebugMenu.Add(new CameraDebugItem("GENERAL", general));
#endif

            PopulateSpecific<BoneCameraPosition>(Path.Combine(TuningShops.location, "Cameras", "Bone"));
            PopulateSpecific<ModCameraPosition>(Path.Combine(TuningShops.location, "Cameras", "Mod"));
            PopulateAssociations();
        }
        /// <summary>
        /// Gets a Camera with a specific ID.
        /// </summary>
        /// <param name="id">The ID of the camera.</param>
        public static CameraCore Get(Guid id) => cameras.TryGetValue(id, out CameraCore camera) ? camera : cameras[Guid.Empty];
        /// <summary>
        /// Gets a Camera for the specified Mod Menu.
        /// </summary>
        /// <param name="base">The menu to use as a base.</param>
        public static CameraCore Get(BaseType @base)
        {
            Model model = Game.Player.Character.CurrentVehicle.Model;
            Type type = @base.GetType();
            string name = type.FullName;

            if (OverrideManager.GetCameraOverride(name, model, out Guid @override))
            {
                return Get(@override);
            }
            else if (associations.TryGetValue(name, out Guid guid))
            {
                return Get(guid);
            }
            else
            {
                Notification.Show($"~o~Warning~s~: No Camera Association for {name}");
                return Get(Guid.Empty);
            }
        }

        #endregion
    }
}
