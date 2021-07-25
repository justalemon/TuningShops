using GTA;
using System;
using TuningShops.Cameras;
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
                CameraManager.Get(Guid.Parse("f69346c6-6b13-4d89-923f-f101e327c71e")).Create(Game.Player.Character.CurrentVehicle);
            };
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.FrontLeftDoor].Close();
        }

        #endregion
    }
}
