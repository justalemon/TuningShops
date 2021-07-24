using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The front bumper menu option.
    /// </summary>
    public class LSCBumperFront : LosSantosCustoms
    {
        #region Constructor

        public LSCBumperFront() : base(1, "Front Bumper")
        {
            Opening += (sender, e) => CameraSet.FrontBumper.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
