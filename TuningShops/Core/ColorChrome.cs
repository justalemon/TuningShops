using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// Sets a chromed color.
    /// </summary>
    public abstract class ColorChrome : Color
    {
        #region Constructor

        public ColorChrome(ColorSlot slot, int value) : base(slot, "Chrome")
        {
            Add(new ColorItem("Chrome", 120, slot, value));
        }

        #endregion
    }
}
