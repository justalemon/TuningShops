using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The suspension menu option.
    /// </summary>
    public class LSCSuspension : LosSantosCustoms
    {
        #region Constructor

        public LSCSuspension() : base(15, "Suspension")
        {
            Opening += (sender, e) => Cameras.FrontLeftWheel(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
