using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The exhaust menu option.
    /// </summary>
    public class LSCHood : LosSantosCustoms
    {
        #region Constructor

        public LSCHood() : base(7, "Hood")
        {
            Opening += (sender, e) => Cameras.Hood(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
