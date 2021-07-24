using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The rear wheels menu option on a bike.
    /// </summary>
    public class LSCWheelsRear : LosSantosCustoms
    {
        #region Constructor

        public LSCWheelsRear() : base(24, "Rear Wheel")
        {
            Opening += (sender, e) => CameraSet.RearLeftWheel.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanUse(Vehicle vehicle)
        {
            return base.CanUse(vehicle) && vehicle.Model.IsBike;
        }

        #endregion
    }
}
