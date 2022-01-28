using GTA;
using GTA.Native;
using TuningShops.Core;
using Color = System.Drawing.Color;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select the tire smoke options.
    /// </summary>
    internal class TireSmokeItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// THe color of the tire smoke.
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructor

        public TireSmokeItem(string text, Color color, int price) : base($"{text} Tire Smoke", price)
        {
            Color = color;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the tire smoke color.
        /// </summary>
        public override void Apply()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 20, true);
            Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, Color.R, Color.G, Color.B);
        }

        #endregion
    }
}
