using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// Sets a matte color.
    /// </summary>
    internal abstract class ColorMatte : Color
    {
        #region Constructor

        public ColorMatte(ColorSlot slot, int value) : base(slot, "Matte")
        {
            Add(new ColorItem("Black", 12, slot, value));
            Add(new ColorItem("Gray", 13, slot, value));
            Add(new ColorItem("Light Gray", 14, slot, value));
            Add(new ColorItem("Ice White", 131, slot, value));
            Add(new ColorItem("Blue", 83, slot, value));
            Add(new ColorItem("Dark Blue", 82, slot, value));
            Add(new ColorItem("Midnight Blue", 84, slot, value));
            Add(new ColorItem("Midnight Purple", 149, slot, value));
            Add(new ColorItem("Schafter Purple", 148, slot, value));
            Add(new ColorItem("Red", 39, slot, value));
            Add(new ColorItem("Dark Red", 40, slot, value));
            Add(new ColorItem("Orange", 41, slot, value));
            Add(new ColorItem("Yellow", 42, slot, value));
            Add(new ColorItem("Lime Green", 55, slot, value));
            Add(new ColorItem("Green", 128, slot, value));
            Add(new ColorItem("Forest Green", 151, slot, value));
            Add(new ColorItem("Foliage Green", 155, slot, value));
            Add(new ColorItem("Olive Darb", 152, slot, value));
            Add(new ColorItem("Dark Earth", 153, slot, value));
            Add(new ColorItem("Desert Tan", 154, slot, value));
        }

        #endregion
    }
}
