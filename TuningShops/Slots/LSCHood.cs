using GTA;
using TuningShops.Cameras;
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
            Opening += (sender, e) => CameraSet.Hood.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
