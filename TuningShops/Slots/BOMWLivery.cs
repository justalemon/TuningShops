using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The livery option.
    /// </summary>
    public class BOMWLivery : LosSantosCustoms
    {
        #region Constructor

        public BOMWLivery() : base(48, "Livery")
        {
            Opening += (sender, e) => CameraSet.General.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
