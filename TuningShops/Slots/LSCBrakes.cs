using GTA;
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
            Opening += (sender, e) => Cameras.General(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
