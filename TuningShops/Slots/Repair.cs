using System.ComponentModel;
using TuningShops.Core;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu option used to repair the vehicle.
    /// </summary>
    internal class Repair : ModificationSlot
    {
        #region Fields

        private readonly RepairItem item = new RepairItem();

        #endregion

        #region Properties

        /// <inheritdoc/>
        public override bool CanBeUsed => true;

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
        public override void Repopulate()
        {
        }
        /// <inheritdoc/>
        public override void SelectCurrent()
        {
        }

        #endregion
    }
}
