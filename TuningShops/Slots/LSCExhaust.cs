using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The exhaust menu option.
    /// </summary>
    public class LSCExhaust : LosSantosCustoms
    {
        #region Constructor

        public LSCExhaust() : base(4, "Exhaust")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("e4887a89-c12c-4085-ab9c-d47e1aa5a923")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
