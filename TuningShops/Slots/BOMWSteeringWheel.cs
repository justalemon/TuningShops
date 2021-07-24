using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The steering wheel option.
    /// </summary>
    public class BOMWSteeringWheel : LosSantosCustoms
    {
        #region Constructor

        public BOMWSteeringWheel() : base(33, "Steering Wheel")
        {
            Opening += (sender, e) => CameraSet.SteeringWheel.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
