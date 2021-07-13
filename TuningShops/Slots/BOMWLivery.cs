using GTA;
using System.ComponentModel;
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
            Opening += (sender, e) => Cameras.General(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
