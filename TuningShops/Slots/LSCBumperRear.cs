using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The rear bumper menu option.
    /// </summary>
    public class LSCBumperRear : LosSantosCustoms
    {
        #region Constructor

        public LSCBumperRear() : base(2, "Rear Bumper")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("fa9362d1-fff3-43bf-ae36-79b917ded591")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
