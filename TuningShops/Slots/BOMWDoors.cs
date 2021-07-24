using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The doors option.
    /// </summary>
    public class BOMWDoors : LosSantosCustoms
    {
        #region Constructor

        public BOMWDoors() : base(31, "Doors")
        {
            Opening += (sender, e) =>
            {
                Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.FrontLeftDoor].Open();
                Cameras.FrontLeftDoor(Game.Player.Character.CurrentVehicle);
            };
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.FrontLeftDoor].Close();
        }

        #endregion
    }
}
