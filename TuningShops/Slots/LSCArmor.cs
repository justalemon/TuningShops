using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The armor menu option.
    /// </summary>
    public class LSCArmor : LosSantosCustoms
    {
        #region Constructor

        public LSCArmor() : base(16, "Armor")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Empty).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
