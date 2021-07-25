using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The air filter option.
    /// </summary>
    public class BOMWAirFilter : LosSantosCustoms
    {
        #region Constructor

        public BOMWAirFilter() : base(40, "Air Filter")
        {
            Opening += (sender, e) => Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.Hood].Open();
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.Hood].Close();
        }

        #endregion
    }
}
