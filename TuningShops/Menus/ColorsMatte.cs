namespace TuningShops.Menus
{
    /// <summary>
    /// Sets a matte color.
    /// </summary>
    internal abstract class ColorsMatte : Colors
    {
        #region Constructor

        public ColorsMatte(ColorSlot slot, int value) : base(slot, "Matte")
        {
            Add(new ColorsItem("Black", 12, slot, value));
            Add(new ColorsItem("Gray", 13, slot, value));
            Add(new ColorsItem("Light Gray", 14, slot, value));
            Add(new ColorsItem("Ice White", 131, slot, value));
            Add(new ColorsItem("Blue", 83, slot, value));
            Add(new ColorsItem("Dark Blue", 82, slot, value));
            Add(new ColorsItem("Midnight Blue", 84, slot, value));
            Add(new ColorsItem("Midnight Purple", 149, slot, value));
            Add(new ColorsItem("Schafter Purple", 148, slot, value));
            Add(new ColorsItem("Red", 39, slot, value));
            Add(new ColorsItem("Dark Red", 40, slot, value));
            Add(new ColorsItem("Orange", 41, slot, value));
            Add(new ColorsItem("Yellow", 42, slot, value));
            Add(new ColorsItem("Lime Green", 55, slot, value));
            Add(new ColorsItem("Green", 128, slot, value));
            Add(new ColorsItem("Forest Green", 151, slot, value));
            Add(new ColorsItem("Foliage Green", 155, slot, value));
            Add(new ColorsItem("Olive Darb", 152, slot, value));
            Add(new ColorsItem("Dark Earth", 153, slot, value));
            Add(new ColorsItem("Desert Tan", 154, slot, value));
        }

        #endregion
    }
}
