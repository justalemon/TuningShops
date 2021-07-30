namespace TuningShops.Core
{
    /// <summary>
    /// Sets a matte color.
    /// </summary>
    public class ColorMatte : Color
    {
        #region Constructor

        public ColorMatte(ColorSlot slot, int value) : base(slot, "Matte")
        {
            Add(new ColorItem(this, "Black", 12, slot, value));
            Add(new ColorItem(this, "Gray", 13, slot, value));
            Add(new ColorItem(this, "Light Gray", 14, slot, value));
            Add(new ColorItem(this, "Ice White", 131, slot, value));
            Add(new ColorItem(this, "Blue", 83, slot, value));
            Add(new ColorItem(this, "Dark Blue", 82, slot, value));
            Add(new ColorItem(this, "Midnight Blue", 84, slot, value));
            Add(new ColorItem(this, "Midnight Purple", 149, slot, value));
            Add(new ColorItem(this, "Schafter Purple", 148, slot, value));
            Add(new ColorItem(this, "Red", 39, slot, value));
            Add(new ColorItem(this, "Dark Red", 40, slot, value));
            Add(new ColorItem(this, "Orange", 41, slot, value));
            Add(new ColorItem(this, "Yellow", 42, slot, value));
            Add(new ColorItem(this, "Lime Green", 55, slot, value));
            Add(new ColorItem(this, "Green", 128, slot, value));
            Add(new ColorItem(this, "Forest Green", 151, slot, value));
            Add(new ColorItem(this, "Foliage Green", 155, slot, value));
            Add(new ColorItem(this, "Olive Darb", 152, slot, value));
            Add(new ColorItem(this, "Dark Earth", 153, slot, value));
            Add(new ColorItem(this, "Desert Tan", 154, slot, value));
        }

        #endregion
    }
}
