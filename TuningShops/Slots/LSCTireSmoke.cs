using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Core;
using TuningShops.Items;
using Color = System.Drawing.Color;

namespace TuningShops.Slots
{
    /// <summary>
    /// The tire smoke menu option.
    /// </summary>
    public class LSCTireSmoke : LosSantosCustoms
    {
        #region Properties

        /// <summary>
        /// If the Tire Smoke option should be repopulated.
        /// </summary>
        public override bool ShouldRepopulate => false;

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

            Shown += LSCTireSmoke_Shown;
            Closed += LSCTireSmoke_Closed;
        }

        #endregion

        #region Events

        private void LSCTireSmoke_Shown(object sender, EventArgs e)
        {
            Ped ped = Game.Player.Character;
            Vehicle vehicle = ped.CurrentVehicle;

            Game.Player.CanControlCharacter = false;
            vehicle.IsPositionFrozen = false;
            vehicle.CanTiresBurst = false;
            Function.Call(Hash.TASK_VEHICLE_TEMP_ACTION, ped, vehicle, 30, 60 * 60 * 24);
        }
        private void LSCTireSmoke_Closed(object sender, EventArgs e)
        {
            Ped ped = Game.Player.Character;
            Vehicle vehicle = ped.CurrentVehicle;

            Game.Player.CanControlCharacter = true;
            vehicle.IsPositionFrozen = true;
            vehicle.CanTiresBurst = true;
            ped.Task.ClearAll();
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
    }
}
