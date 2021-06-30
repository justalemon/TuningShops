using GTA;

namespace TuningShops.Base
{
    /// <summary>
    /// The basics for all Terrorbyte customizations.
    /// </summary>
    public class Terrorbyte : BaseType
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

        #endregion
    }
}
