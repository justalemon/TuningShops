using GTA;
using GTA.Native;
using System;

namespace TuningShops.Items
{
    internal class RepairItem : CoreItem
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

        public RepairItem() : base(0, "Repair", "", 0)
        {
            Activated += RepairItem_Activated;
        }

        #endregion

        #region Events

        private void RepairItem_Activated(object sender, EventArgs e)
        {
            if (Money.ChargeIfPossible(Value))
            {
                Game.Player.Character.CurrentVehicle?.Repair();
                Value = 0;
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Updates the price of the vehicle repair.
        /// </summary>
        public void UpdatePrice()
        {
            Value = RepairPrice;
        }

        #endregion
    }
}
