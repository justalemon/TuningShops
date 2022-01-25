using GTA;
using TuningShops.Extensions;

namespace TuningShops.Core
{
    /// <summary>
    /// Basics for the Mobile Operations Center related stuff.
    /// </summary>
    internal abstract class MobileOperationsCenter : SpecialVehicle
    {
        #region Constructor

        public MobileOperationsCenter(string title) : base(title)
        {
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle has an MOC attached.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if there is an MOC attached, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            Vehicle trailer = vehicle.GetTrailer();
            return trailer != null && trailer.Model == VehicleHash.TrailerLarge;
        }

        #endregion
    }
}
