using GTA;
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
            Opening += (sender, e) => Cameras.Spoiler(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
