using GTA;
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
            Opening += (sender, e) => CameraSet.FrontLeftWheel.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
