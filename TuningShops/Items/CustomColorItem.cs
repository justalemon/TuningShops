using TuningShops.Core;
using Color = System.Drawing.Color;

namespace TuningShops.Items
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

        public CustomColorItem(Color color, string name, int value) : base(name, "", value)
        {
            Color = color;
        }

        #endregion
    }
}
