using GTA;
using GTA.Native;
using System;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// The turbo menu option.
    /// </summary>
    internal class LSCTurbo : LosSantosCustoms
    {
        #region Properties

        /// <inheritdoc/>
        public override bool ShouldRepopulate => false;

        #endregion

        #region Constructor

        public LSCTurbo() : base(18, "Turbo")
        {
            CoreItem n = new CoreItem(0, "None", "", 200);
            CoreItem y = new CoreItem(1, "Turbo Tuning", "", 500);

            n.Activated += N_Activated;
            y.Activated += Y_Activated;

            Add(n);
            Add(y);
        }

        #endregion

        #region Tools

        public void Toggle(bool enabled)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 18, enabled);
        }

        #endregion

        #region Events

        private void N_Activated(object sender, EventArgs e) => Toggle(false);
        private void Y_Activated(object sender, EventArgs e) => Toggle(true);

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanUse(Vehicle vehicle) => vehicle.Model.IsCar;
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
            SelectedIndex = Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, vehicle, 18) ? 1 : 0;
            UpdateBadges();
        }

        #endregion
    }
}
