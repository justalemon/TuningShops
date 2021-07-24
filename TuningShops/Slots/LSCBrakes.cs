using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The brakes menu option.
    /// </summary>
    public class LSCBrakes : LosSantosCustoms
    {
        #region Constructor

        public LSCBrakes() : base(12, "Brakes")
        {
            Opening += (sender, e) => CameraSet.FrontLeftWheel.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
