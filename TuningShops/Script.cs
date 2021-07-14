using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI;
using LemonUI.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using TuningShops.Core;
using Color = System.Drawing.Color;

namespace TuningShops
{
    /// <summary>
    /// The main class that handles the Tuning Shop features.
    /// </summary>
    public class TuningShops : Script
    {
        #region Fields

        internal static string location = Path.Combine(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath, "TuningShops");
        internal static readonly ObjectPool pool = new ObjectPool();
        private static readonly List<ShopLocation> locations = new List<ShopLocation>();

        #endregion

        #region Constructor

        public TuningShops()
        {
            // We are going to need the current assembly later
            Assembly assembly = Assembly.GetAssembly(typeof(TuningShops));

            // Try to load all of the locations
            string locationsPath = Path.Combine(location, "Locations");
            if (Directory.Exists(locationsPath))
            {
                foreach (string file in Directory.EnumerateFiles(locationsPath))
                {
                    if (Path.GetExtension(file).ToLowerInvariant() != ".json")
                    {
                        Notification.Show($"~o~Warning~s~: Non JSON file found in the Locations Directory! ({Path.GetFileName(file)})");
                        continue;
                    }

                    string contents = File.ReadAllText(file);
                    ShopLocation location;
                    try
                    {
                        location = JsonConvert.DeserializeObject<ShopLocation>(contents);
                    }
                    catch (Exception e)
                    {
                        Notification.Show($"~o~Warning~s~: Unable to load Location {Path.GetFileName(file)}:\n{e.Message}");
                        continue;
                    }

                    if (location.Interior.HasValue)
                    {
                        if (Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, location.Interior.Value.X, location.Interior.Value.Y, location.Interior.Value.Z) == 0)
                        {
                            Notification.Show($"~o~Warning~s~: Interior of {location.Name} is not available! Maybe you forgot to install it?");
                            continue;
                        }
                    }

                    if (location.PedInfo != null && !location.PedInfo.Model.IsPed)
                    {
                        Notification.Show($"~o~Warning~s~: Model {location.PedInfo.Model} is not a Ped!");
                        continue;
                    }

                    ScaledTexture texture = null;
                    if (!string.IsNullOrWhiteSpace(location.BannerTXD) && !string.IsNullOrWhiteSpace(location.BannerTexture))
                    {
                        texture = new ScaledTexture(PointF.Empty, new SizeF(0, 108), location.BannerTXD, location.BannerTexture);
                    }
                    MainMenu menu = new MainMenu(location, texture);
                    pool.Add(menu);
                    location.Menu = menu;
                    locations.Add(location);

                    foreach (string @class in location.Mods)
                    {
                        Type type = assembly.GetType(@class);

                        if (type == null || !type.IsSubclassOf(typeof(BaseType)) || type == typeof(BaseType))
                        {
                            Notification.Show($"~o~Warning~s~: Modification Type {@class} is not valid!");
                            continue;
                        }

                        BaseType newMenu;
                        try
                        {
                            newMenu = (BaseType)Activator.CreateInstance(type);
                        }
                        catch (MissingMethodException)
                        {
                            Notification.Show($"~o~Warning~s~: Unable to load {@class}: No matching public constructor");
                            continue;
                        }

                        pool.Add(newMenu);
                        menu.AddMenu(newMenu);
                        ScaledTexture newBanner = null;
                        if (!string.IsNullOrWhiteSpace(location.BannerTXD) && !string.IsNullOrWhiteSpace(location.BannerTexture))
                        {
                            newBanner = new ScaledTexture(PointF.Empty, new SizeF(0, 108), location.BannerTXD, location.BannerTexture);
                        }
                        newMenu.Banner = newBanner;
                    }
                }
            }
            else
            {
                Notification.Show($"~o~Warning~s~: Locations Directory was not found!");
            }

            // Finally, add the tick event and start working
            Tick += TuningShops_Tick_Init;
            Aborted += TuningShops_Aborted;
        }

        #endregion

        #region Events

        private void TuningShops_Tick_Init(object sender, EventArgs e)
        {
            foreach (ShopLocation location in locations)
            {
                location.Initialize();
            }
            Tick -= TuningShops_Tick_Init;
            Tick += TuningShops_Tick_Run;
        }
        private void TuningShops_Tick_Run(object sender, EventArgs e)
        {
            // Process the contents of the menus and return if anything is open
            pool.Process();
            if (pool.AreAnyVisible)
            {
                return;
            }

            // Get some of the user's information to use it later
            Vector3 pos = Game.Player.Character.Position;

            // Time to check every single location
            foreach (ShopLocation location in locations)
            {
                // If the player is very far away, skip it completely
                if (pos.DistanceTo(location.Trigger) > 50)
                {
                    continue;
                }

                // Draw the marker
                World.DrawMarker(MarkerType.VerticalCylinder, location.Trigger, Vector3.Zero, Vector3.Zero, new Vector3(location.TriggerSize, location.TriggerSize, 1), Color.Purple);

                // Check if the activation distance and open the menu if requested
                if (pos.DistanceTo(location.Trigger) < 5)
                {
                    if (Game.IsControlJustPressed(Control.Context))
                    {
                        location.Menu.Visible = true;
                        return;
                    }
                }
            }
        }

        private void TuningShops_Aborted(object sender, EventArgs e)
        {
            Game.Player.CanControlCharacter = true;

            pool.HideAll();
            // Just in case HideAll() didn't worked
            Game.Player.Character.Opacity = 255;
            Cameras.ClearCamera();

            foreach (ShopLocation location in locations)
            {
                location.DoCleanup();
            }
        }

        #endregion
    }
}
