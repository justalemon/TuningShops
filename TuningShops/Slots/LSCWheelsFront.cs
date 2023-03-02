using GTA;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// The front wheel menu option on a bike.
    /// </summary>
    internal class LSCWheelsFront : LosSantosCustoms
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

                return base.CanBeUsed && vehicle.Model.IsBike && vehicle.Wheels.Count > 0;
            }
        }

        #endregion

        #region Constructor

        public LSCWheelsFront() : base(23, "Front Wheel")
        {
        }

        #endregion
    }
}
