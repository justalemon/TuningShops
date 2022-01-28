namespace TuningShops.Menus
{
    /// <summary>
    /// Sets a metal color.
    /// </summary>
    internal abstract class ColorsMetals : Colors
    {
        #region Constructor

        public ColorsMetals(ColorSlot slot, int value) : base(slot, "Metal")
        {
            Add(new ColorsItem("Brushed Steel", 117, slot, value));
            Add(new ColorsItem("Brushed Black Steel", 118, slot, value));
            Add(new ColorsItem("Brushed Aluminum", 119, slot, value));
            Add(new ColorsItem("Pure Gold", 158, slot, value));
            Add(new ColorsItem("Brushed Gold", 159, slot, value));
        }

        #endregion
    }
}
