using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The exhaust menu option.
    /// </summary>
    public class LSCHood : LosSantosCustoms
    {
        #region Constructor

        public LSCHood() : base(7, "Hood")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("6e16303b-f64b-4aea-8368-7d29fae07898")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
