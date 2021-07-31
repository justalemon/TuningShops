using GTA;
using GTA.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TuningShops.Overrides
{
    /// <summary>
    /// Manages the vehicle specific overrides.
    /// </summary>
    public static class OverrideManager
    {
        #region Fields

        private static readonly Dictionary<Model, Dictionary<string, Guid>> cameras = new Dictionary<Model, Dictionary<string, Guid>>();
        private static readonly Dictionary<Model, Dictionary<string, string>> names = new Dictionary<Model, Dictionary<string, string>>();

        #endregion

        #region Tools

        private static void PopulateSpecificOverrides(string path)
        {
            if (!path.ToLowerInvariant().EndsWith(".json"))
            {
                Notification.Show($"~o~Warning~s~: File {path} is not a JSON File!");
                return;
            }

            try
            {
                string contents = File.ReadAllText(path);
                List<Override> @new = JsonConvert.DeserializeObject<List<Override>>(contents);

                foreach (Override @override in @new)
                {
                    Dictionary<string, Guid> cam;
                    if (cameras.ContainsKey(@override.Model))
                    {
                        cam = cameras[@override.Model];
                    }
                    else
                    {
                        cam = new Dictionary<string, Guid>();
                        cameras.Add(@override.Model, cam);
                    }

                    foreach (KeyValuePair<string, Guid> newCamera in @override.Cameras)
                    {
                        if (cam.ContainsKey(newCamera.Key))
                        {
                            Notification.Show($"~o~Warning~s~: Model {@override.Model} already has a Camera Override for {newCamera.Key}!");
                            continue;
                        }
                        cam.Add(newCamera.Key, newCamera.Value);
                    }

                    Dictionary<string, string> name;
                    if (names.ContainsKey(@override.Model))
                    {
                        name = names[@override.Model];
                    }
                    else
                    {
                        name = new Dictionary<string, string>();
                        names.Add(@override.Model, name);
                    }

                    foreach (KeyValuePair<string, string> newName in @override.Names)
                    {
                        if (name.ContainsKey(newName.Key))
                        {
                            Notification.Show($"~o~Warning~s~: Model {@override.Model} already has a Name Override for {newName.Key}!");
                            continue;
                        }
                        name.Add(newName.Key, newName.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Notification.Show($"~o~Warning~s~: Unable to load Camera Override:\n{ex.Message}");
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Gets the Camera Override for a specific model
        /// </summary>
        /// <param name="name">The name of the menu.</param>
        /// <param name="model">The model to look for.</param>
        /// <param name="id">The found GUID, or an empty GUID.</param>
        /// <returns>true if there was an override found, false otherwise.</returns>
        public static bool GetCameraOverride(string name, Model model, out Guid id)
        {
            if (cameras.ContainsKey(model))
            {
                if (cameras[model].TryGetValue(name, out Guid found))
                {
                    id = found;
                    return true;
                }
            }

            id = Guid.Empty;
            return false;
        }
        /// <summary>
        /// Gets the name for a menu.
        /// </summary>
        /// <param name="name">The name of the menu.</param>
        /// <param name="model">The model to look for.</param>
        /// <param name="id">The found name, or an empty string.</param>
        /// <returns>true if a custom name was found, false otherwise.</returns>
        public static bool GetName(string name, Model model, out string @class)
        {
            if (names.ContainsKey(model))
            {
                if (names[model].TryGetValue(name, out string found))
                {
                    @class = found;
                    return true;
                }
            }

            @class = "";
            return false;
        }
        /// <summary>
        /// Populates all of the overrides.
        /// </summary>
        public static void Populate()
        {
            cameras.Clear();

            string path = Path.Combine(TuningShops.location, "Overrides");

            foreach (string file in Directory.EnumerateFiles(path))
            {
                PopulateSpecificOverrides(file);
            }
        }

        #endregion
    }
}
