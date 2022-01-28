using GTA;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// The rear wheels menu option on a bike.
    /// </summary>
    internal class LSCWheelsRear : LosSantosCustoms
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

                return base.CanBeUsed && vehicle.Model.IsBike;
            }
        }

        #endregion

        #region Constructor

        public LSCWheelsRear() : base(24, "Rear Wheel")
        {
        }

        #endregion
    }
}
