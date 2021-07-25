using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The front wheel menu option on a bike.
    /// </summary>
    public class LSCWheelsFront : LosSantosCustoms
    {
        #region Constructor

        public LSCWheelsFront() : base(23, "Front Wheel")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("dd182935-09ae-45e9-b81c-888a09afbd69")).Create(Game.Player.Character.CurrentVehicle);
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
