namespace TuningShops.Core
{
    /// <summary>
    /// Sets a metal color.
    /// </summary>
    public class ColorMetals : Color
    {
        #region Constructor

        public ColorMetals(ColorSlot slot) : base(slot, "Metal")
        {
            Add(new ColorItem(this, "Brushed Steel", 117, slot));
            Add(new ColorItem(this, "Brushed Black Steel", 118, slot));
            Add(new ColorItem(this, "Brushed Aluminum", 119, slot));
            Add(new ColorItem(this, "Pure Gold", 158, slot));
            Add(new ColorItem(this, "Brushed Gold", 159, slot));
        }

        #endregion
    }
}
