using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// Sets a wheel color.
    /// </summary>
    public class ColorWheels : Color
    {
        #region Constructor

        public ColorWheels(ColorSlot slot, int value) : base(slot, "")
        {
            Add(new ColorItem("Alloy", 156, slot, value));
            Add(new ColorItem("Black", 0, slot, value));
            Add(new ColorItem("Carbon Black", 1, slot, value));
            Add(new ColorItem("Anthracite Black", 11, slot, value));
            Add(new ColorItem("Black Steel", 2, slot, value));
            Add(new ColorItem("Stone Silver", 8, slot, value));
            Add(new ColorItem("Frost White", 112, slot, value));
            Add(new ColorItem("Red", 27, slot, value));
            Add(new ColorItem("Blaze Red", 30, slot, value));
            Add(new ColorItem("Garnet Red", 45, slot, value));
            Add(new ColorItem("Candy Red", 35, slot, value));
            Add(new ColorItem("Sunset Red", 33, slot, value));
            Add(new ColorItem("Salmon Pink", 136, slot, value));
            Add(new ColorItem("Hot Pink", 135, slot, value));
            Add(new ColorItem("Sunrise Orange", 36, slot, value));
            Add(new ColorItem("Orange", 41, slot, value));
            Add(new ColorItem("Bright Orange", 138, slot, value));
            Add(new ColorItem("Gold", 37, slot, value));
            Add(new ColorItem("Straw Brown", 99, slot, value));
            Add(new ColorItem("Dark Copper", 90, slot, value));
            Add(new ColorItem("Dark Ivory", 95, slot, value));
            Add(new ColorItem("Dark Brown", 115, slot, value));
            Add(new ColorItem("Bronze", 109, slot, value));
            Add(new ColorItem("Dark Earth", 153, slot, value));
            Add(new ColorItem("Desert Tan", 154, slot, value));
            Add(new ColorItem("Yellow", 88, slot, value));
            Add(new ColorItem("Race Yellow", 89, slot, value));
            Add(new ColorItem("Yellow Bird", 91, slot, value));
            Add(new ColorItem("Lime Green", 55, slot, value));
            Add(new ColorItem("Pea Green", 125, slot, value));
            Add(new ColorItem("Green", 53, slot, value));
            Add(new ColorItem("Dark Green", 56, slot, value));
            Add(new ColorItem("Olive Green", 151, slot, value));
            Add(new ColorItem("Midnight Blue", 82, slot, value));
            Add(new ColorItem("Royal Blue", 64, slot, value));
            Add(new ColorItem("Baby Blue", 87, slot, value));
            Add(new ColorItem("Bright Blue", 70, slot, value));
            Add(new ColorItem("Fluorescent Blue", 140, slot, value));
            Add(new ColorItem("Slate Blue", 81, slot, value));
            Add(new ColorItem("Shafter Purple", 145, slot, value));
            Add(new ColorItem("Midnight Purple", 142, slot, value));
        }

        #endregion
    }
}
