using GTA.Native;
using GTA;
using LemonUI.Menus;
using System;
using System.Drawing;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select the tire smoke options.
    /// </summary>
    public class TireSmokeItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// THe color of the tire smoke.
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructor

        public TireSmokeItem(string text, Color color) : base($"{text} Tire Smoke")
        {
            Color = color;
            Activated += TireSmokeItem_Activated;
        }

        #endregion

        #region Events

        private void TireSmokeItem_Activated(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 20, true);
            Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, Color.R, Color.G, Color.B);
        }

        #endregion
    }
}
