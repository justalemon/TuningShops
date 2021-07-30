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
            Add(new ColorItem(this, "Alloy", 156, slot, value));
            Add(new ColorItem(this, "Black", 0, slot, value));
            Add(new ColorItem(this, "Carbon Black", 1, slot, value));
            Add(new ColorItem(this, "Anthracite Black", 11, slot, value));
            Add(new ColorItem(this, "Black Steel", 2, slot, value));
            Add(new ColorItem(this, "Stone Silver", 8, slot, value));
            Add(new ColorItem(this, "Frost White", 112, slot, value));
            Add(new ColorItem(this, "Red", 27, slot, value));
            Add(new ColorItem(this, "Blaze Red", 30, slot, value));
            Add(new ColorItem(this, "Garnet Red", 45, slot, value));
            Add(new ColorItem(this, "Candy Red", 35, slot, value));
            Add(new ColorItem(this, "Sunset Red", 33, slot, value));
            Add(new ColorItem(this, "Salmon Pink", 136, slot, value));
            Add(new ColorItem(this, "Hot Pink", 135, slot, value));
            Add(new ColorItem(this, "Sunrise Orange", 36, slot, value));
            Add(new ColorItem(this, "Orange", 41, slot, value));
            Add(new ColorItem(this, "Bright Orange", 138, slot, value));
            Add(new ColorItem(this, "Gold", 37, slot, value));
            Add(new ColorItem(this, "Straw Brown", 99, slot, value));
            Add(new ColorItem(this, "Dark Copper", 90, slot, value));
            Add(new ColorItem(this, "Dark Ivory", 95, slot, value));
            Add(new ColorItem(this, "Dark Brown", 115, slot, value));
            Add(new ColorItem(this, "Bronze", 109, slot, value));
            Add(new ColorItem(this, "Dark Earth", 153, slot, value));
            Add(new ColorItem(this, "Desert Tan", 154, slot, value));
            Add(new ColorItem(this, "Yellow", 88, slot, value));
            Add(new ColorItem(this, "Race Yellow", 89, slot, value));
            Add(new ColorItem(this, "Yellow Bird", 91, slot, value));
            Add(new ColorItem(this, "Lime Green", 55, slot, value));
            Add(new ColorItem(this, "Pea Green", 125, slot, value));
            Add(new ColorItem(this, "Green", 53, slot, value));
            Add(new ColorItem(this, "Dark Green", 56, slot, value));
            Add(new ColorItem(this, "Olive Green", 151, slot, value));
            Add(new ColorItem(this, "Midnight Blue", 82, slot, value));
            Add(new ColorItem(this, "Royal Blue", 64, slot, value));
            Add(new ColorItem(this, "Baby Blue", 87, slot, value));
            Add(new ColorItem(this, "Bright Blue", 70, slot, value));
            Add(new ColorItem(this, "Fluorescent Blue", 140, slot, value));
            Add(new ColorItem(this, "Slate Blue", 81, slot, value));
            Add(new ColorItem(this, "Shafter Purple", 145, slot, value));
            Add(new ColorItem(this, "Midnight Purple", 142, slot, value));
        }

        #endregion
    }
}
