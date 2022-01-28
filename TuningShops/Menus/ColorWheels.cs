namespace TuningShops.Menus
{
    /// <summary>
    /// Sets a wheel color.
    /// </summary>
    internal abstract class ColorWheels : Colors
    {
        #region Constructor

        public ColorWheels(ColorSlot slot, int value) : base(slot, "")
        {
            Add(new ColorsItem("Alloy", 156, slot, value));
            Add(new ColorsItem("Black", 0, slot, value));
            Add(new ColorsItem("Carbon Black", 1, slot, value));
            Add(new ColorsItem("Anthracite Black", 11, slot, value));
            Add(new ColorsItem("Black Steel", 2, slot, value));
            Add(new ColorsItem("Stone Silver", 8, slot, value));
            Add(new ColorsItem("Frost White", 112, slot, value));
            Add(new ColorsItem("Red", 27, slot, value));
            Add(new ColorsItem("Blaze Red", 30, slot, value));
            Add(new ColorsItem("Garnet Red", 45, slot, value));
            Add(new ColorsItem("Candy Red", 35, slot, value));
            Add(new ColorsItem("Sunset Red", 33, slot, value));
            Add(new ColorsItem("Salmon Pink", 136, slot, value));
            Add(new ColorsItem("Hot Pink", 135, slot, value));
            Add(new ColorsItem("Sunrise Orange", 36, slot, value));
            Add(new ColorsItem("Orange", 41, slot, value));
            Add(new ColorsItem("Bright Orange", 138, slot, value));
            Add(new ColorsItem("Gold", 37, slot, value));
            Add(new ColorsItem("Straw Brown", 99, slot, value));
            Add(new ColorsItem("Dark Copper", 90, slot, value));
            Add(new ColorsItem("Dark Ivory", 95, slot, value));
            Add(new ColorsItem("Dark Brown", 115, slot, value));
            Add(new ColorsItem("Bronze", 109, slot, value));
            Add(new ColorsItem("Dark Earth", 153, slot, value));
            Add(new ColorsItem("Desert Tan", 154, slot, value));
            Add(new ColorsItem("Yellow", 88, slot, value));
            Add(new ColorsItem("Race Yellow", 89, slot, value));
            Add(new ColorsItem("Yellow Bird", 91, slot, value));
            Add(new ColorsItem("Lime Green", 55, slot, value));
            Add(new ColorsItem("Pea Green", 125, slot, value));
            Add(new ColorsItem("Green", 53, slot, value));
            Add(new ColorsItem("Dark Green", 56, slot, value));
            Add(new ColorsItem("Olive Green", 151, slot, value));
            Add(new ColorsItem("Midnight Blue", 82, slot, value));
            Add(new ColorsItem("Royal Blue", 64, slot, value));
            Add(new ColorsItem("Baby Blue", 87, slot, value));
            Add(new ColorsItem("Bright Blue", 70, slot, value));
            Add(new ColorsItem("Fluorescent Blue", 140, slot, value));
            Add(new ColorsItem("Slate Blue", 81, slot, value));
            Add(new ColorsItem("Shafter Purple", 145, slot, value));
            Add(new ColorsItem("Midnight Purple", 142, slot, value));
        }

        #endregion
    }
}
