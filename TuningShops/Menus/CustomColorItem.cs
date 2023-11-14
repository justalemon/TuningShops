using System.Drawing;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Item to set custom colors.
    /// </summary>
    public abstract class CustomColorItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The color set by this item.
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new custom color item.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="name">The name of the color.</param>
        /// <param name="value">The value of the color in the store.</param>
        public CustomColorItem(Color color, string name, int value) : base(name, "", value)
        {
            Color = color;
        }

        #endregion
    }
}
