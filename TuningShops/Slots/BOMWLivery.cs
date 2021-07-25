using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The livery option.
    /// </summary>
    public class BOMWLivery : LosSantosCustoms
    {
        #region Constructor

        public BOMWLivery() : base(48, "Livery")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Empty).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
