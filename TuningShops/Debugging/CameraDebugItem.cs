﻿#if DEBUG
using GTA;
using LemonUI.Menus;
using System;
using TuningShops.Cameras;

namespace TuningShops.Debugging
{
    /// <summary>
    /// The item that temporarely activates the camera.
    /// </summary>
    internal class CameraDebugItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// The camera that gets activated by this menu.
        /// </summary>
        public CustomCamera Camera { get; set; }

        #endregion

        #region Constructor

        public CameraDebugItem(string filename, CustomCamera cam) : base(filename, cam.Id.ToString())
        {
            Camera = cam;
            Activated += CameraDebugItem_Activated;
        }

        #endregion

        #region Events

        private void CameraDebugItem_Activated(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Camera.Create(vehicle);
        }

        #endregion
    }
}
#endif
