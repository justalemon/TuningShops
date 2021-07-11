namespace TuningShops.Core
{
    /// <summary>
    /// Sets a wheel color.
    /// </summary>
    public class ColorWheels : Color
    {
        #region Constructor

        public ColorWheels(ColorSlot slot) : base(slot, "")
        {
            Add(new ColorItem("Alloy", 156, slot));
            Add(new ColorItem("Black", 0, slot));
            Add(new ColorItem("Carbon Black", 1, slot));
            Add(new ColorItem("Anthracite Black", 11, slot));
            Add(new ColorItem("Black Steel", 2, slot));
            Add(new ColorItem("Stone Silver", 8, slot));
            Add(new ColorItem("Frost White", 112, slot));
            Add(new ColorItem("Red", 27, slot));
            Add(new ColorItem("Blaze Red", 30, slot));
            Add(new ColorItem("Garnet Red", 45, slot));
            Add(new ColorItem("Candy Red", 35, slot));
            Add(new ColorItem("Sunset Red", 33, slot));
            Add(new ColorItem("Salmon Pink", 136, slot));
            Add(new ColorItem("Hot Pink", 135, slot));
            Add(new ColorItem("Sunrise Orange", 36, slot));
            Add(new ColorItem("Orange", 41, slot));
            Add(new ColorItem("Bright Orange", 138, slot));
            Add(new ColorItem("Gold", 37, slot));
            Add(new ColorItem("Straw Brown", 99, slot));
            Add(new ColorItem("Dark Copper", 90, slot));
            Add(new ColorItem("Dark Ivory", 95, slot));
            Add(new ColorItem("Dark Brown", 115, slot));
            Add(new ColorItem("Bronze", 109, slot));
            Add(new ColorItem("Dark Earth", 153, slot));
            Add(new ColorItem("Desert Tan", 154, slot));
            Add(new ColorItem("Yellow", 88, slot));
            Add(new ColorItem("Race Yellow", 89, slot));
            Add(new ColorItem("Yellow Bird", 91, slot));
            Add(new ColorItem("Lime Green", 55, slot));
            Add(new ColorItem("Pea Green", 125, slot));
            Add(new ColorItem("Green", 53, slot));
            Add(new ColorItem("Dark Green", 56, slot));
            Add(new ColorItem("Olive Green", 151, slot));
            Add(new ColorItem("Midnight Blue", 82, slot));
            Add(new ColorItem("Royal Blue", 64, slot));
            Add(new ColorItem("Baby Blue", 87, slot));
            Add(new ColorItem("Bright Blue", 70, slot));
            Add(new ColorItem("Fluorescent Blue", 140, slot));
            Add(new ColorItem("Slate Blue", 81, slot));
            Add(new ColorItem("Shafter Purple", 145, slot));
            Add(new ColorItem("Midnight Purple", 142, slot));
        }

        #endregion
    }
}
