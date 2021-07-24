using GTA;
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
            Opening += (sender, e) => Cameras.SteeringWheel(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
