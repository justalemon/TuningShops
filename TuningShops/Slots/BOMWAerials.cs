using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The aerials option.
    /// </summary>
    public class BOMWAerials : LosSantosCustoms
    {
        #region Constructor

        public BOMWAerials() : base(43, "Aerials")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("16d5e2ea-c3d4-46b4-8129-6fc83acf1785")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
