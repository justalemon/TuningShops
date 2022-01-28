namespace TuningShops.Menus
{
    /// <summary>
    /// Sets a chromed color.
    /// </summary>
    internal abstract class ColorsChrome : Colors
    {
        #region Constructor

        public ColorsChrome(ColorSlot slot, int value) : base(slot, "Chrome")
        {
            Add(new ColorsItem("Chrome", 120, slot, value));
        }

        #endregion
    }
}
