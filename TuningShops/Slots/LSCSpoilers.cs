using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The spoilers menu option.
    /// </summary>
    public class LSCSpoilers : LosSantosCustoms
    {
        #region Constructor

        public LSCSpoilers() : base(0, "Spoilers")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("eb3fb67e-9008-40c5-af1d-12f4856b3fbc")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
