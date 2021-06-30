using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using System.Drawing;
using TuningShops.Base;

namespace TuningShops.Slots
{
    /// <summary>
    /// The tire smoke menu option.
    /// </summary>
    public class LSCTireSmoke : LSC
    {
        #region Properties

        /// <summary>
        /// If the Tire Smoke option should be repopulated.
        /// </summary>
        public override bool Repopulate => false;

        #endregion

        #region Constructor

        public LSCTireSmoke() : base(20, "Tire Smoke")
        {
            Add(new TireSmokeItem("White", Color.FromArgb(255, 255, 255, 255)));
            Add(new TireSmokeItem("Black", Color.FromArgb(255, 20, 20, 20)));
            Add(new TireSmokeItem("Blue", Color.FromArgb(255, 0, 174, 239)));
            Add(new TireSmokeItem("Yellow", Color.FromArgb(255, 252, 238, 0)));
            Add(new TireSmokeItem("Orange", Color.FromArgb(255, 255, 127, 0)));
            Add(new TireSmokeItem("Red", Color.FromArgb(255, 255, 6, 6)));
            Add(new TireSmokeItem("Purple", Color.FromArgb(255, 100, 79, 142)));
            Add(new TireSmokeItem("Green", Color.FromArgb(255, 102, 152, 104)));
            Add(new TireSmokeItem("Pink", Color.FromArgb(255, 203, 54, 148)));
            Add(new TireSmokeItem("Brown", Color.FromArgb(255, 180, 130, 97)));
            Add(new TireSmokeItem("Patriot", Color.FromArgb(255, 0, 0, 0)));
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle can use the Tire Smoke options.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if the vehicle can use it, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            Model model = vehicle.Model;
            return model.IsVehicle || model.IsBike || model.IsBicycle;
        }

        #endregion

        #region Tire Smoke Item

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

        #endregion
    }
}
