using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The ornaments option.
    /// </summary>
    public class BOMWOrnaments : LosSantosCustoms
    {
        #region Constructor

        public BOMWOrnaments() : base(28, "Ornaments")
        {
            Opening += (sender, e) => CameraSet.Ornament.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
