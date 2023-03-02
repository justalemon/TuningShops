using GTA;
using GTA.Native;
using TuningShops.Core;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    internal class LSCBulletproof : ModificationSlot<bool>
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

                return vehicle.Wheels.Count > 0;
            }
        }

        #endregion

        #region Constructors

        public LSCBulletproof() : base("Bulletproof Tires")
        {
            StoreItem n = new Bulletproof(false);
            StoreItem y = new Bulletproof(true);

            Add(n);
            Add(y);
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            SelectedIndex = Function.Call<bool>(Hash.GET_VEHICLE_TYRES_CAN_BURST, Game.Player.Character.CurrentVehicle) ? 1 : 0;
            UpdateBadges();
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
