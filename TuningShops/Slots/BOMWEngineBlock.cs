using GTA;
using System;
using TuningShops.Cameras;
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
            Opening += (sender, e) =>
            {
                Game.Player.Character.CurrentVehicle.Doors[VehicleDoorIndex.Hood].Open();
                CameraManager.Get(Guid.Parse("d0699f69-4b97-4e14-93aa-020b9a6a47e5")).Create(Game.Player.Character.CurrentVehicle);
            };
            Closing += (sender, e) => Game.Player.Character.CurrentVehicle?.Doors[VehicleDoorIndex.Hood].Close();
        }

        #endregion
    }
}
