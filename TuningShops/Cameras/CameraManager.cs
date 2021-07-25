using GTA.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Manages all of the Part specific Cameras.
    /// </summary>
    public static class CameraManager
    {
        #region Fields

        private static readonly Dictionary<Guid, CameraCore> cameras = new Dictionary<Guid, CameraCore>();

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
                }
                catch (Exception ex)
                {
                    Notification.Show($"~o~Warning~s~: Unable to load {Path.GetFileName(file)}:\n{ex.Message}");
                }
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
            cameras.Add(Guid.Empty, new GeneralCamera());
            PopulateSpecific<BoneCameraPosition>(Path.Combine(TuningShops.location, "Cameras", "Bone"));
            PopulateSpecific<ModCameraPosition>(Path.Combine(TuningShops.location, "Cameras", "Mod"));
        }
        /// <summary>
        /// Gets a Camera with a specific ID.
        /// </summary>
        /// <param name="id">The ID of the camera.</param>
        public static CameraCore Get(Guid id) => cameras.TryGetValue(id, out CameraCore camera) ? camera : cameras[Guid.Empty];

        #endregion
    }
}
