using GTA;
using GTA.Native;
using System;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Item used to repair the vehicle.
    /// </summary>
    internal class RepairItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The price of the entire vehicle repair.
        /// </summary>
        public static int RepairPrice
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;
                int value = Function.Call<int>((Hash)0x5873C14A52D74236, vehicle.Model);

                float percentage = vehicle.HealthFloat / vehicle.MaxHealthFloat;
                return value - (int)(value * percentage);
            }
        }

        #endregion

        #region Constructor

        public RepairItem() : base("Repair", 0)
        {
            Activated += RepairItem_Activated;
        }

        #endregion

        #region Events

        private void RepairItem_Activated(object sender, EventArgs e)
        {
            if (Money.ChargeIfPossible(Price))
            {
                Game.Player.Character.CurrentVehicle?.Repair();
                Price = 0;
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Updates the price of the vehicle repair.
        /// </summary>
        public void UpdatePrice()
        {
            Price = RepairPrice;
        }
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Apply()
        {
        }

        #endregion
    }
}
