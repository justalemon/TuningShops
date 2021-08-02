﻿using GTA;
using GTA.Native;
using GTA.UI;
using LemonUI;
using System;
using System.IO;
using System.Reflection;
using TuningShops.Cameras;
using TuningShops.Locations;
using TuningShops.Memory;
using TuningShops.Overrides;

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
        internal static unsafe CVehicleModelInfoVarGlobal** gVehicleModelInfoVarGlobal = null;

        #endregion

        #region Constructor

        public TuningShops()
        {
            // Get the pattern of the global vehicle info
            unsafe
            {
                byte* address = MemoryPatterns.FindPattern("\x48\x8B\x0D\x00\x00\x00\x00\x44\x8B\xC6\x8B\xD5\x8B\xD8", "xxx????xxxxxxx");
                if (address == null)
                {
                    throw new NullReferenceException(nameof(address));
                }
                gVehicleModelInfoVarGlobal = (CVehicleModelInfoVarGlobal**)(address + *(int*)(address + 3) + 7);
            }

            // And add the tick event and start working
            Tick += TuningShops_Tick_Init;
            Aborted += TuningShops_Aborted;
        }

        #endregion

        #region Events

        private void TuningShops_Tick_Init(object sender, EventArgs e)
        {
            LocationManager.Populate();
            CameraManager.Populate();
            OverrideManager.Populate();

            Tick -= TuningShops_Tick_Init;
            Tick += TuningShops_Tick_Run;
        }
        private void TuningShops_Tick_Run(object sender, EventArgs e)
        {
            if (Game.WasCheatStringJustEntered("tsloc"))
            {
                LocationManager.Populate();
                Notification.Show($"~q~Locations have been reloaded!");
            }
            else if (Game.WasCheatStringJustEntered("tscam"))
            {
                CameraManager.Populate();
                Notification.Show($"~q~Cameras have been reloaded!");
            }
            else if (Game.WasCheatStringJustEntered("tsover"))
            {
                OverrideManager.Populate();
                Notification.Show($"~q~Overrides have been reloaded!");
            }

            pool.Process();
            LocationManager.Process();
        }

        private void TuningShops_Aborted(object sender, EventArgs e)
        {
            pool.HideAll();

            if (LocationManager.Active != null)
            {
                Game.Player.CanControlCharacter = true;
                Game.Player.Character.IsVisible = true;

                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle != null)
                {
                    vehicle.IsPositionFrozen = false;
                    Function.Call(Hash.SET_VEHICLE_LIGHTS, vehicle, 0);
                }
            }

            CameraCore.Destroy();
            LocationManager.DoCleanup();
        }

        #endregion
    }
}
