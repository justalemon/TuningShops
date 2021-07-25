using GTA;
using System;
using TuningShops.Cameras;
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
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("dd182935-09ae-45e9-b81c-888a09afbd69")).Create(Game.Player.Character.CurrentVehicle);
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
