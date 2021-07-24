using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The rear bumper menu option.
    /// </summary>
    public class LSCBumperRear : LosSantosCustoms
    {
        #region Constructor

        public LSCBumperRear() : base(2, "Rear Bumper")
        {
            Opening += (sender, e) => CameraSet.RearBumper.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
