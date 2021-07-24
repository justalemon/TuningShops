using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The turbo menu option.
    /// </summary>
    public class LSCTurbo : LosSantosCustoms
    {
        #region Properties

        /// <inheritdoc/>
        public override bool ShouldRepopulate => false;

        #endregion

        #region Constructor

        public LSCTurbo() : base(18, "Turbo")
        {
            NativeItem n = new NativeItem("None");
            NativeItem y = new NativeItem("Turbo Tuning");

            n.Activated += N_Activated;
            y.Activated += Y_Activated;

            Add(n);
            Add(y);

            Opening += (sender, e) =>
            {
                Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.Hood].Open();
                CameraSet.Engine.Create(Game.Player.Character.CurrentVehicle);
            };
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.Hood].Close();
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
        }

        #endregion
    }
}
