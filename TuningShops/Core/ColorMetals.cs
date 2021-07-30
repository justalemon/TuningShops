namespace TuningShops.Core
{
    /// <summary>
    /// Sets a metal color.
    /// </summary>
    public class ColorMetals : Color
    {
        #region Constructor

        public ColorMetals(ColorSlot slot, int value) : base(slot, "Metal")
        {
            Add(new ColorItem("Brushed Steel", 117, slot, value));
            Add(new ColorItem("Brushed Black Steel", 118, slot, value));
            Add(new ColorItem("Brushed Aluminum", 119, slot, value));
            Add(new ColorItem("Pure Gold", 158, slot, value));
            Add(new ColorItem("Brushed Gold", 159, slot, value));
        }

        #endregion
    }
}
