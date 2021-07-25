using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The brakes menu option.
    /// </summary>
    public class LSCBrakes : LosSantosCustoms
    {
        #region Constructor

        public LSCBrakes() : base(12, "Brakes")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("dd182935-09ae-45e9-b81c-888a09afbd69")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
