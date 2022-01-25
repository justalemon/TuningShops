using System.Drawing;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select the tire smoke options.
    /// </summary>
    internal class TireSmokeItem : CoreItem
    {
        #region Properties

        /// <summary>
        /// THe color of the tire smoke.
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructor

        public TireSmokeItem(string text, Color color, int price) : base(0, $"{text} Tire Smoke", "", price)
        {
            Color = color;
        }

        #endregion
    }
}
