using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The engine block option.
    /// </summary>
    public class BOMWEngineBlock : LosSantosCustoms
    {
        #region Constructor

        public BOMWEngineBlock() : base(39, "Engine Block")
        {
            Opening += (sender, e) => Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.Hood].Open();
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.Hood].Close();
        }

        #endregion
    }
}
