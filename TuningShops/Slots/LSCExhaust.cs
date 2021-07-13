using GTA;
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
            Opening += (sender, e) => Cameras.Exhaust(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
