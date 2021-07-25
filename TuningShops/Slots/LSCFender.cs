using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The fender menu option.
    /// </summary>
    public class LSCFender : LosSantosCustoms
    {
        #region Constructor

        public LSCFender() : base(8, "Fender")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("fe02bfe7-0794-4919-a4b2-6a5b1e7b51ca")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
