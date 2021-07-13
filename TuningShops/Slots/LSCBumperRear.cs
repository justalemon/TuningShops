using GTA;
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
            Opening += (sender, e) => Cameras.RearBumper(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
