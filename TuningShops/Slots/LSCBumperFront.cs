using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The front bumper menu option.
    /// </summary>
    public class LSCBumperFront : LosSantosCustoms
    {
        #region Constructor

        public LSCBumperFront() : base(1, "Front Bumper")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("cfd055ed-a292-4862-9681-16c015a6fd4f")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
