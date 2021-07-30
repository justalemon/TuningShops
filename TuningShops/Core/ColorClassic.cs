namespace TuningShops.Core
{
    /// <summary>
    /// Sets a classic color.
    /// </summary>
    public class ColorClassic : Color
    {
        #region Constructor

        public ColorClassic(ColorSlot slot, string name) : base(slot, name)
        {
            Add(new ColorItem(this, "Black", 0, slot));
            Add(new ColorItem(this, "Carbon Black", 147, slot));
            Add(new ColorItem(this, "Graphite", 1, slot));
            Add(new ColorItem(this, "Anthracite Black", 11, slot));
            Add(new ColorItem(this, "Black Steel", 2, slot));
            Add(new ColorItem(this, "Dark Steel", 3, slot));
            Add(new ColorItem(this, "Silver", 3, slot));
            Add(new ColorItem(this, "Bluish Silver", 5, slot));
            Add(new ColorItem(this, "Rolled Steel", 6, slot));
            Add(new ColorItem(this, "Shadow Silver", 7, slot));
            Add(new ColorItem(this, "Stone Silver", 8, slot));
            Add(new ColorItem(this, "Midnight Silver", 9, slot));
            Add(new ColorItem(this, "Cast Iron Silver", 10, slot));
            Add(new ColorItem(this, "Red", 27, slot));
            Add(new ColorItem(this, "Torino Red", 28, slot));
            Add(new ColorItem(this, "Formula Red", 29, slot));
            Add(new ColorItem(this, "Lava Red", 150, slot));
            Add(new ColorItem(this, "Blaze Red", 30, slot));
            Add(new ColorItem(this, "Grace Red", 31, slot));
            Add(new ColorItem(this, "Garnet Red", 32, slot));
            Add(new ColorItem(this, "Sunset Red", 33, slot));
            Add(new ColorItem(this, "Cabernet Red", 34, slot));
            Add(new ColorItem(this, "Wine Red", 143, slot));
            Add(new ColorItem(this, "Candy Red", 35, slot));
            Add(new ColorItem(this, "Hot Pink", 135, slot));
            Add(new ColorItem(this, "Pfsiter Pink", 137, slot));
            Add(new ColorItem(this, "Salmon Pink", 136, slot));
            Add(new ColorItem(this, "Sunrise Orange", 36, slot));
            Add(new ColorItem(this, "Orange", 38, slot));
            Add(new ColorItem(this, "Bright Orange", 138, slot));
            Add(new ColorItem(this, "Gold", 99, slot));
            Add(new ColorItem(this, "Bronze", 90, slot));
            Add(new ColorItem(this, "Yellow", 88, slot));
            Add(new ColorItem(this, "Race Yellow", 89, slot));
            Add(new ColorItem(this, "Dew Yellow", 91, slot));
            Add(new ColorItem(this, "Dark Green", 49, slot));
            Add(new ColorItem(this, "Racing Green", 50, slot));
            Add(new ColorItem(this, "Sea Green", 51, slot));
            Add(new ColorItem(this, "Olive Green", 52, slot));
            Add(new ColorItem(this, "Bright Green", 53, slot));
            Add(new ColorItem(this, "Gasoline Green", 54, slot));
            Add(new ColorItem(this, "Lime Green", 92, slot));
            Add(new ColorItem(this, "Midnight Blue", 141, slot));
            Add(new ColorItem(this, "Galaxy Blue", 61, slot));
            Add(new ColorItem(this, "Dark Blue", 62, slot));
            Add(new ColorItem(this, "Saxon Blue", 63, slot));
            Add(new ColorItem(this, "Blue", 64, slot));
            Add(new ColorItem(this, "Mariner Blue", 65, slot));
            Add(new ColorItem(this, "Harbor Blue", 66, slot));
            Add(new ColorItem(this, "Diamond Blue", 67, slot));
            Add(new ColorItem(this, "Surf Blue", 68, slot));
            Add(new ColorItem(this, "Nautical Blue", 69, slot));
            Add(new ColorItem(this, "Racing Blue", 73, slot));
            Add(new ColorItem(this, "Ultra Blue", 70, slot));
            Add(new ColorItem(this, "Light Blue", 74, slot));
            Add(new ColorItem(this, "Chocolate Brown", 96, slot));
            Add(new ColorItem(this, "Bison Brown", 101, slot));
            Add(new ColorItem(this, "Creeen Brown", 95, slot));
            Add(new ColorItem(this, "Feltzer Brown", 94, slot));
            Add(new ColorItem(this, "Maple Brown", 97, slot));
            Add(new ColorItem(this, "Beechwood Brown", 103, slot));
            Add(new ColorItem(this, "Sienna Brown", 104, slot));
            Add(new ColorItem(this, "Saddle Brown", 98, slot));
            Add(new ColorItem(this, "Moss Brown", 100, slot));
            Add(new ColorItem(this, "Woodbeech Brown", 102, slot));
            Add(new ColorItem(this, "Straw Brown", 99, slot));
            Add(new ColorItem(this, "Sandy Brown", 105, slot));
            Add(new ColorItem(this, "Bleached Brown", 106, slot));
            Add(new ColorItem(this, "Schafter Purple", 71, slot));
            Add(new ColorItem(this, "Spinnaker Purple", 72, slot));
            Add(new ColorItem(this, "Midnight Purple", 142, slot));
            Add(new ColorItem(this, "Bright Purple", 145, slot));
            Add(new ColorItem(this, "Cream", 107, slot));
            Add(new ColorItem(this, "Ice White", 111, slot));
            Add(new ColorItem(this, "Frost White", 112, slot));
        }

        #endregion
    }
}
