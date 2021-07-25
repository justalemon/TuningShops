using GTA;
using LemonUI.Menus;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu option used to repair the vehicle.
    /// </summary>
    public class Repair : BaseType
    {
        #region Constructor

        public Repair() : base("Repair Vehicle")
        {
            NativeItem item = new NativeItem("Repair");
            item.Activated += (sender, e) => Game.Player.Character.CurrentVehicle?.Repair();
            Add(item);
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
