using GTA;
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
            Opening += (sender, e) => CameraSet.Dashboard.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
