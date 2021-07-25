using GTA;
using System;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The dashboard option.
    /// </summary>
    public class BOMWDashboard : LosSantosCustoms
    {
        #region Constructor

        public BOMWDashboard() : base(29, "Dashboard")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("93852b14-3d0c-42bc-bbbc-cc76d18e8fce")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
