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
        public System.Drawing.Color Color { get; }

        #endregion

        #region Constructors

        public CustomColorItem(System.Drawing.Color color, string name, int value) : base(name, "", value)
        {
            Color = color;
        }

        #endregion
    }
}
