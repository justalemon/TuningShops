using System.Drawing;
using GTA;
using GTA.Native;

namespace TuningShops.Menus
{
    /// <summary>
    /// Item used to set custom neon colors.
    /// </summary>
    public class NeonColorItem : CustomColorItem
    {
        #region Constructors

        /// <inheritdoc/>
        public NeonColorItem(Color color, string name) : base(color, name, 650)
        {
        }

        #endregion
        
        #region Functions

        /// <summary>
        /// Applies the neon color.
        /// </summary>
        public override void Apply()
        {
            Vehicle playerVehicle = Game.Player.Character.CurrentVehicle;

            if (playerVehicle == null)
            {
                return;
            }

            Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, playerVehicle.Handle, Color.R, Color.G, Color.B);
        }
        
        #endregion
    }
}
