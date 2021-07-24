using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The air filter option.
    /// </summary>
    public class BOMWAirFilter : LosSantosCustoms
    {
        #region Constructor

        public BOMWAirFilter() : base(40, "Air Filter")
        {
            Opening += (sender, e) => CameraSet.Engine.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
