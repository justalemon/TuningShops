using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The wheels (front wheel on a Bike) menu option.
    /// </summary>
    public class LSCWheels : LosSantosCustoms
    {
        #region Constructor

        public LSCWheels() : base(23, "Wheels")
        {
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanUse(Vehicle vehicle)
        {
            return base.CanUse(vehicle) && !vehicle.Model.IsBike;
        }

        #endregion
    }
}
