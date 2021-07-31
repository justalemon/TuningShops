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

        private static readonly Dictionary<Model, Dictionary<string, Guid>> overrides = new Dictionary<Model, Dictionary<string, Guid>>();

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
                    Dictionary<string, Guid> dict;

                    if (overrides.ContainsKey(@override.Model))
                    {
                        dict = overrides[@override.Model];
                    }
                    else
                    {
                        dict = new Dictionary<string, Guid>();
                        overrides.Add(@override.Model, dict);
                    }

                    foreach (KeyValuePair<string, Guid> newOverride in @override.Cameras)
                    {
                        if (dict.ContainsKey(newOverride.Key))
                        {
                            Notification.Show($"~o~Warning~s~: Model {@override.Model} already has an Override for {newOverride.Key}!");
                            continue;
                        }

                        dict.Add(newOverride.Key, newOverride.Value);
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
            if (overrides.ContainsKey(model))
            {
                if (overrides[model].TryGetValue(name, out Guid found))
                {
                    id = found;
                    return true;
                }
            }

            id = Guid.Empty;
            return false;
        }
        /// <summary>
        /// Populates all of the overrides.
        /// </summary>
        public static void Populate()
        {
            overrides.Clear();

            string path = Path.Combine(TuningShops.location, "Overrides");

            foreach (string file in Directory.EnumerateFiles(path))
            {
                PopulateSpecificOverrides(file);
            }
        }

        #endregion
    }
}
