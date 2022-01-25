using GTA;
using System.ComponentModel;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu option used to repair the vehicle.
    /// </summary>
    internal class Repair : BaseType
    {
        #region Fields

        private readonly RepairItem item = new RepairItem();

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
            ShowsAsNonPurchased = true;

            Opening += Repair_Opening;

            Add(item);
        }

        #endregion

        #region Events

        private void Repair_Opening(object sender, CancelEventArgs e)
        {
            item.UpdatePrice();
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
        /// <inheritdoc/>
        public override int GetPrice(int index) => 0;

        #endregion
    }
}
