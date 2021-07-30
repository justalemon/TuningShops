namespace TuningShops.Core
{
    /// <summary>
    /// Sets a chromed color.
    /// </summary>
    public class ColorChrome : Color
    {
        #region Constructor

        public ColorChrome(ColorSlot slot, int value) : base(slot, "Chrome")
        {
            Add(new ColorItem(this, "Chrome", 120, slot, value));
        }

        #endregion
    }
}
