using GTA;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// The wheels (front wheel on a Bike) menu option.
    /// </summary>
    internal class LSCWheels : LosSantosCustoms
    {
        #region Properties

        /// <inheritdoc/>
        public override bool CanBeUsed
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return false;
                }

                return base.CanBeUsed && !vehicle.Model.IsBike && vehicle.Wheels.Count > 0;
            }
        }

        #endregion

        #region Constructor

        public LSCWheels() : base(23, "Wheels")
        {
        }

        #endregion
    }
}
