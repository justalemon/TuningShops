namespace TuningShops.Core
{
    /// <summary>
    /// Sets a matte color.
    /// </summary>
    public class ColorMatte : Color
    {
        #region Constructor

        public ColorMatte(ColorSlot slot) : base(slot, "Matte")
        {
            Add(new ColorItem("Black", 12, slot));
            Add(new ColorItem("Gray", 13, slot));
            Add(new ColorItem("Light Gray", 14, slot));
            Add(new ColorItem("Ice White", 131, slot));
            Add(new ColorItem("Blue", 83, slot));
            Add(new ColorItem("Dark Blue", 82, slot));
            Add(new ColorItem("Midnight Blue", 84, slot));
            Add(new ColorItem("Midnight Purple", 149, slot));
            Add(new ColorItem("Schafter Purple", 148, slot));
            Add(new ColorItem("Red", 39, slot));
            Add(new ColorItem("Dark Red", 40, slot));
            Add(new ColorItem("Orange", 41, slot));
            Add(new ColorItem("Yellow", 42, slot));
            Add(new ColorItem("Lime Green", 55, slot));
            Add(new ColorItem("Green", 128, slot));
            Add(new ColorItem("Forest Green", 151, slot));
            Add(new ColorItem("Foliage Green", 155, slot));
            Add(new ColorItem("Olive Darb", 152, slot));
            Add(new ColorItem("Dark Earth", 153, slot));
            Add(new ColorItem("Desert Tan", 154, slot));
        }

        #endregion
    }
}
