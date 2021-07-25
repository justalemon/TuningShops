using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The steering wheel option.
    /// </summary>
    public class BOMWSteeringWheel : LosSantosCustoms
    {
        #region Constructor

        public BOMWSteeringWheel() : base(33, "Steering Wheel")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("f69346c6-6b13-4d89-923f-f101e327c71e")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
