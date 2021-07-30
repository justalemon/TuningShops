using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using System.ComponentModel;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu option used to repair the vehicle.
    /// </summary>
    public class Repair : BaseType
    {
        #region Fields

        private readonly NativeItem item = new NativeItem("Repair");
        private int repairPrice = 0;

        #endregion

        #region Properties

        /// <inheritdoc/>
        public override int ModValue
        {
            get => 0;
            set
            {
            }
        }

        #endregion

        #region Constructor

        public Repair() : base("Repair Vehicle")
        {
            item.Activated += Item_Activated;
            Opening += Repair_Opening;

            Add(item);
        }

        #endregion

        #region Tools

        private static int GetRepairPrice()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            int value = Function.Call<int>((Hash)0x5873C14A52D74236, vehicle.Model);

            float percentage = vehicle.HealthFloat / vehicle.MaxHealthFloat;
            return value - (int)(value * percentage);
        }

        #endregion

        #region Events

        private void Item_Activated(object sender, EventArgs e)
        {
            if (Money.ChargeIfPossible(repairPrice))
            {
                Game.Player.Character.CurrentVehicle?.Repair();
                repairPrice = 0;
                item.AltTitle = "$0";
            }
        }
        private void Repair_Opening(object sender, CancelEventArgs e)
        {
            repairPrice = GetRepairPrice();
            item.AltTitle = $"${repairPrice}";
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanUse(Vehicle vehicle) => true;
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
        }

        #endregion
    }
}
