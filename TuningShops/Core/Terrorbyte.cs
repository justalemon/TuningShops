using GTA;

namespace TuningShops.Core
{
    /// <summary>
    /// The basics for all Terrorbyte customizations.
    /// </summary>
    internal abstract class Terrorbyte : SpecialVehicle
    {
        #region Constructor

        public Terrorbyte(string title) : base(title)
        {
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the player vehicle is a Terrorbyte.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if is a Terrorbyte, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle) => vehicle.Model == VehicleHash.Terrorbyte;
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
