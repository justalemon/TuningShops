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
    internal class LSCTurbo : ModificationSlot<bool>
    {
        #region Properties

        /// <inheritdoc/>
        public override bool CanBeUsed
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return false;
                }

                return vehicle.Model.IsCar;
            }
        }

        #endregion

        #region Constructor

        public LSCTurbo() : base("Turbo")
        {
            StoreItem n = new ModToggleItem(18, false, "None", 200);
            StoreItem y = new ModToggleItem(18, false, "Turbo Tuning", 500);

            Add(n);
            Add(y);
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            SelectedIndex = Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, vehicle, 18) ? 1 : 0;
            UpdateBadges();
        }
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
