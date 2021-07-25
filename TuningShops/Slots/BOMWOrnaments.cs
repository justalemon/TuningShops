using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The ornaments option.
    /// </summary>
    public class BOMWOrnaments : LosSantosCustoms
    {
        #region Constructor

        public BOMWOrnaments() : base(28, "Ornaments")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("1950becc-7be9-409e-98ae-fcb6a85e2f32")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
