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
            Add(new ColorItem(this, "Alloy", 156, slot));
            Add(new ColorItem(this, "Black", 0, slot));
            Add(new ColorItem(this, "Carbon Black", 1, slot));
            Add(new ColorItem(this, "Anthracite Black", 11, slot));
            Add(new ColorItem(this, "Black Steel", 2, slot));
            Add(new ColorItem(this, "Stone Silver", 8, slot));
            Add(new ColorItem(this, "Frost White", 112, slot));
            Add(new ColorItem(this, "Red", 27, slot));
            Add(new ColorItem(this, "Blaze Red", 30, slot));
            Add(new ColorItem(this, "Garnet Red", 45, slot));
            Add(new ColorItem(this, "Candy Red", 35, slot));
            Add(new ColorItem(this, "Sunset Red", 33, slot));
            Add(new ColorItem(this, "Salmon Pink", 136, slot));
            Add(new ColorItem(this, "Hot Pink", 135, slot));
            Add(new ColorItem(this, "Sunrise Orange", 36, slot));
            Add(new ColorItem(this, "Orange", 41, slot));
            Add(new ColorItem(this, "Bright Orange", 138, slot));
            Add(new ColorItem(this, "Gold", 37, slot));
            Add(new ColorItem(this, "Straw Brown", 99, slot));
            Add(new ColorItem(this, "Dark Copper", 90, slot));
            Add(new ColorItem(this, "Dark Ivory", 95, slot));
            Add(new ColorItem(this, "Dark Brown", 115, slot));
            Add(new ColorItem(this, "Bronze", 109, slot));
            Add(new ColorItem(this, "Dark Earth", 153, slot));
            Add(new ColorItem(this, "Desert Tan", 154, slot));
            Add(new ColorItem(this, "Yellow", 88, slot));
            Add(new ColorItem(this, "Race Yellow", 89, slot));
            Add(new ColorItem(this, "Yellow Bird", 91, slot));
            Add(new ColorItem(this, "Lime Green", 55, slot));
            Add(new ColorItem(this, "Pea Green", 125, slot));
            Add(new ColorItem(this, "Green", 53, slot));
            Add(new ColorItem(this, "Dark Green", 56, slot));
            Add(new ColorItem(this, "Olive Green", 151, slot));
            Add(new ColorItem(this, "Midnight Blue", 82, slot));
            Add(new ColorItem(this, "Royal Blue", 64, slot));
            Add(new ColorItem(this, "Baby Blue", 87, slot));
            Add(new ColorItem(this, "Bright Blue", 70, slot));
            Add(new ColorItem(this, "Fluorescent Blue", 140, slot));
            Add(new ColorItem(this, "Slate Blue", 81, slot));
            Add(new ColorItem(this, "Shafter Purple", 145, slot));
            Add(new ColorItem(this, "Midnight Purple", 142, slot));
        }

        #endregion
    }
}
