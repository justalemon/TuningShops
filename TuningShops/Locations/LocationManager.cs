using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using LemonUI.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using TuningShops.Cameras;
using TuningShops.Core;
using Color = System.Drawing.Color;

namespace TuningShops.Locations
{
    /// <summary>
    /// Manages the different locations in the game world.
    /// </summary>
    internal static class LocationManager
    {
        #region Fields

        private static readonly Assembly assembly = Assembly.GetAssembly(typeof(TuningShops));
        private static readonly List<Location> locations = new List<Location>();

        #endregion

        #region Properties

        /// <summary>
        /// The currently active location.
        /// </summary>
        public static Location Active { get; private set; }

        #endregion

        #region Tools

        public static void LoadFrom(string path)
        {
            if (!path.ToLowerInvariant().EndsWith(".json"))
            {
                Notification.Show($"~o~Warning~s~: File {path} is not a JSON File!");
                return;
            }

            try
            {
                string contents = File.ReadAllText(path);

                Location location = JsonConvert.DeserializeObject<Location>(contents);

                foreach (string dlc in location.DlcsRequired)
                {
                    if (!Function.Call<bool>(Hash.IS_DLC_PRESENT, Game.GenerateHash(dlc)))
                    {
                        Notification.Show($"~o~Warning~s~: DLC {dlc} for location {location.Name} is not installed! Maybe you forgot to install it?");
                        return;
                    }
                }

                if (location.Interior.HasValue)
                {
                    if (Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, location.Interior.Value.X, location.Interior.Value.Y, location.Interior.Value.Z) == 0)
                    {
                        Notification.Show($"~o~Warning~s~: Interior of {location.Name} is not available! Maybe you forgot to install it?");
                        return;
                    }
                }

                if (location.PedInfo != null)
                {
                    if (!location.PedInfo.Model.IsPed)
                    {
                        Notification.Show($"~o~Warning~s~: Model {location.PedInfo.Model} is not a Ped!");
                        return;
                    }

                    location.PedInfo.Model.Request();
                    while (!location.PedInfo.Model.IsLoaded)
                    {
                        Script.Yield();
                    }
                    location.Ped = World.CreatePed(location.PedInfo.Model, location.PedInfo.Position, location.PedInfo.Heading);
                    location.Ped.IsPositionFrozen = true;
                    location.Ped.BlockPermanentEvents = true;
                    location.Ped.CanBeTargetted = false;
                    location.Ped.CanRagdoll = false;
                    location.Ped.CanWrithe = false;
                    location.Ped.IsInvincible = true;
                    location.PedInfo.Model.MarkAsNoLongerNeeded();
                }

                location.Blip = World.CreateBlip(location.Trigger);
                location.Blip.Sprite = BlipSprite.LosSantosCustoms;
                Function.Call(Hash.SET_BLIP_COLOUR, location.Blip, (TuningShops.Config.BlipColorR << 24) + (TuningShops.Config.BlipColorG << 16) + (TuningShops.Config.BlipColorB << 8) + TuningShops.Config.BlipColorA);
                location.Blip.Name = $"Tuning Shop: {location.Name}";
                location.Blip.IsShortRange = true;

                ScaledTexture texture = null;
                if (!string.IsNullOrWhiteSpace(location.BannerTXD) && !string.IsNullOrWhiteSpace(location.BannerTexture))
                {
                    texture = new ScaledTexture(PointF.Empty, new SizeF(0, 108), location.BannerTXD, location.BannerTexture);
                }

                MainMenu menu = new MainMenu(location, texture);
                TuningShops.pool.Add(menu);

                location.Menu = menu;
                
                foreach (string @class in location.Mods)
                {
                    Type type = assembly.GetType(@class);

                    if (type == null || !type.IsSubclassOf(typeof(ModificationSlot)) || type == typeof(ModificationSlot))
                    {
                        Notification.Show($"~o~Warning~s~: Modification Type {@class} is not valid!");
                        continue;
                    }

                    ModificationSlot newMenu;
                    try
                    {
                        newMenu = (ModificationSlot)Activator.CreateInstance(type);
                    }
                    catch (MissingMethodException)
                    {
                        Notification.Show($"~o~Warning~s~: Unable to load {@class}: No matching public constructor");
                        continue;
                    }
                    catch (TargetInvocationException e)
                    {
                        Notification.Show($"~o~Warning~s~: Unable to load {@class}\n{e.GetType().Name}: {e.Message}");
                        Notification.Show(e.StackTrace);
                        continue;
                    }

                    TuningShops.pool.Add(newMenu);
                    menu.AddMenu(newMenu);
                    ScaledTexture newBanner = null;
                    if (!string.IsNullOrWhiteSpace(location.BannerTXD) && !string.IsNullOrWhiteSpace(location.BannerTexture))
                    {
                        newBanner = new ScaledTexture(PointF.Empty, new SizeF(0, 108), location.BannerTXD, location.BannerTexture);
                    }
                    newMenu.Banner = newBanner;
                }

                locations.Add(location);
            }
            catch (Exception ex)
            {
                Notification.Show($"~o~Warning~s~: Unable to load {Path.GetFileName(path)}\n{ex.GetType().Name}: {ex.Message}");
                Notification.Show(ex.StackTrace);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Populates the locations fron the game files.
        /// </summary>
        public static void Populate()
        {
            DoCleanup();

            string path = Path.Combine(TuningShops.location, "Locations");

            foreach (string file in Directory.EnumerateFiles(path))
            {
                LoadFrom(file);
            }
        }
        /// <summary>
        /// Handles the current set of Locations.
        /// </summary>
        public static void Process()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (Active != null)
            {
                if (!TuningShops.pool.AreAnyVisible)
                {
                    if (Active.Menu.Items.Count > 0)
                    {
                        Active.Menu.SelectedIndex = 0;
                    }

                    if (vehicle != null)
                    {
                        vehicle.IsPositionFrozen = false;
                        Function.Call(Hash.SET_VEHICLE_LIGHTS, vehicle, 0);
                    }

                    CustomCamera.Destroy();

                    Active = null;
                }
                return;
            }

            Vector3 pos = Game.Player.Character.Position;

            foreach (Location location in locations)
            {
                if (pos.DistanceTo(location.Trigger) > TuningShops.Config.MarkerDistance)
                {
                    continue;
                }

                if (TuningShops.Config.ShowMarkers)
                {
                    World.DrawMarker(MarkerType.VerticalCylinder, location.Trigger, Vector3.Zero, Vector3.Zero, new Vector3(location.TriggerSize, location.TriggerSize, 1), Color.FromArgb(TuningShops.Config.MarkerColorA, TuningShops.Config.MarkerColorR, TuningShops.Config.MarkerColorG, TuningShops.Config.MarkerColorB));
                }

                if (pos.DistanceTo(location.Trigger) < (location.TriggerSize * 0.5f) && vehicle != null)
                {
                    Screen.ShowHelpTextThisFrame($"Press ~INPUT_CONTEXT~ to modify your vehicle.");

                    if (Game.IsControlJustPressed(Control.Context))
                    {
                        location.ClearNearby();

                        Function.Call(Hash.SET_VEHICLE_LIGHTS, vehicle, 2);

                        vehicle.PositionNoOffset = location.VehiclePos;
                        vehicle.Heading = location.VehicleHeading;

                        if (location.PlaceOnGround)
                        {
                            vehicle.PlaceOnGround();
                            vehicle.IsPositionFrozen = true;
                        }

                        location.Menu.Visible = true;
                        Active = location;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Cleans up all of the existing locations.
        /// </summary>
        public static void DoCleanup()
        {
            foreach (Location location in locations)
            {
                if (location.Ped != null)
                {
                    location.Ped.Delete();
                    location.Ped = null;
                }
                if (location.Blip != null)
                {
                    location.Blip.Delete();
                    location.Blip = null;
                }
            }

            locations.Clear();
        }

        #endregion
    }
}
