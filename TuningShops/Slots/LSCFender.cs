using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The fender menu option.
    /// </summary>
    public class LSCFender : LosSantosCustoms
    {
        #region Constructor

        public LSCFender() : base(8, "Fender")
        {
            Opening += (sender, e) => Cameras.Fender(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
