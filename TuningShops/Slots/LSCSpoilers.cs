using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The spoilers menu option.
    /// </summary>
    public class LSCSpoilers : LosSantosCustoms
    {
        #region Constructor

        public LSCSpoilers() : base(0, "Spoilers")
        {
            Opening += (sender, e) => CameraSet.Spoiler.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
