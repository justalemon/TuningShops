using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The suspension menu option.
    /// </summary>
    public class LSCSuspension : LosSantosCustoms
    {
        #region Constructor

        public LSCSuspension() : base(15, "Suspension")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("dd182935-09ae-45e9-b81c-888a09afbd69")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
