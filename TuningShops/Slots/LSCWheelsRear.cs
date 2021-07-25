using GTA;
using System;
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
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("ac9cee71-6828-41b8-b3e1-80d07519bd44")).Create(Game.Player.Character.CurrentVehicle);
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
