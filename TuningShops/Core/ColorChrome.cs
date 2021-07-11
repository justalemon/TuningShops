namespace TuningShops.Core
{
    /// <summary>
    /// Sets a chromed color.
    /// </summary>
    public class ColorChrome : Color
    {
        #region Constructor

        public ColorChrome(ColorSlot slot) : base(slot, "Chrome")
        {
            Add(new ColorItem("Chrome", 120, slot));
        }

        #endregion
    }
}
