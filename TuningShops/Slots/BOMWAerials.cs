using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The aerials option.
    /// </summary>
    public class BOMWAerials : LosSantosCustoms
    {
        #region Constructor

        public BOMWAerials() : base(43, "Aerials")
        {
            Opening += (sender, e) => CameraSet.Aerials.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
