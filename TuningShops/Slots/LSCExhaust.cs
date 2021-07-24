using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The exhaust menu option.
    /// </summary>
    public class LSCExhaust : LosSantosCustoms
    {
        #region Constructor

        public LSCExhaust() : base(4, "Exhaust")
        {
            Opening += (sender, e) => CameraSet.Exhaust.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
