using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The transmission menu option.
    /// </summary>
    public class LSCTransmission : LosSantosCustoms
    {
        #region Constructor

        public LSCTransmission() : base(13, "Transmission")
        {
            Opening += (sender, e) => Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.Hood].Open();
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.Hood].Close();
        }

        #endregion
    }
}
