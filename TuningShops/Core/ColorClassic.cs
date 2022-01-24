using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// Sets a classic color.
    /// </summary>
    public abstract class ColorClassic : Color
    {
        #region Constructor

        public ColorClassic(ColorSlot slot, string name, int value) : base(slot, name)
        {
            Add(new ColorItem("Black", 0, slot, value));
            Add(new ColorItem("Carbon Black", 147, slot, value));
            Add(new ColorItem("Graphite", 1, slot, value));
            Add(new ColorItem("Anthracite Black", 11, slot, value));
            Add(new ColorItem("Black Steel", 2, slot, value));
            Add(new ColorItem("Dark Steel", 3, slot, value));
            Add(new ColorItem("Silver", 3, slot, value));
            Add(new ColorItem("Bluish Silver", 5, slot, value));
            Add(new ColorItem("Rolled Steel", 6, slot, value));
            Add(new ColorItem("Shadow Silver", 7, slot, value));
            Add(new ColorItem("Stone Silver", 8, slot, value));
            Add(new ColorItem("Midnight Silver", 9, slot, value));
            Add(new ColorItem("Cast Iron Silver", 10, slot, value));
            Add(new ColorItem("Red", 27, slot, value));
            Add(new ColorItem("Torino Red", 28, slot, value));
            Add(new ColorItem("Formula Red", 29, slot, value));
            Add(new ColorItem("Lava Red", 150, slot, value));
            Add(new ColorItem("Blaze Red", 30, slot, value));
            Add(new ColorItem("Grace Red", 31, slot, value));
            Add(new ColorItem("Garnet Red", 32, slot, value));
            Add(new ColorItem("Sunset Red", 33, slot, value));
            Add(new ColorItem("Cabernet Red", 34, slot, value));
            Add(new ColorItem("Wine Red", 143, slot, value));
            Add(new ColorItem("Candy Red", 35, slot, value));
            Add(new ColorItem("Hot Pink", 135, slot, value));
            Add(new ColorItem("Pfsiter Pink", 137, slot, value));
            Add(new ColorItem("Salmon Pink", 136, slot, value));
            Add(new ColorItem("Sunrise Orange", 36, slot, value));
            Add(new ColorItem("Orange", 38, slot, value));
            Add(new ColorItem("Bright Orange", 138, slot, value));
            Add(new ColorItem("Gold", 99, slot, value));
            Add(new ColorItem("Bronze", 90, slot, value));
            Add(new ColorItem("Yellow", 88, slot, value));
            Add(new ColorItem("Race Yellow", 89, slot, value));
            Add(new ColorItem("Dew Yellow", 91, slot, value));
            Add(new ColorItem("Dark Green", 49, slot, value));
            Add(new ColorItem("Racing Green", 50, slot, value));
            Add(new ColorItem("Sea Green", 51, slot, value));
            Add(new ColorItem("Olive Green", 52, slot, value));
            Add(new ColorItem("Bright Green", 53, slot, value));
            Add(new ColorItem("Gasoline Green", 54, slot, value));
            Add(new ColorItem("Lime Green", 92, slot, value));
            Add(new ColorItem("Midnight Blue", 141, slot, value));
            Add(new ColorItem("Galaxy Blue", 61, slot, value));
            Add(new ColorItem("Dark Blue", 62, slot, value));
            Add(new ColorItem("Saxon Blue", 63, slot, value));
            Add(new ColorItem("Blue", 64, slot, value));
            Add(new ColorItem("Mariner Blue", 65, slot, value));
            Add(new ColorItem("Harbor Blue", 66, slot, value));
            Add(new ColorItem("Diamond Blue", 67, slot, value));
            Add(new ColorItem("Surf Blue", 68, slot, value));
            Add(new ColorItem("Nautical Blue", 69, slot, value));
            Add(new ColorItem("Racing Blue", 73, slot, value));
            Add(new ColorItem("Ultra Blue", 70, slot, value));
            Add(new ColorItem("Light Blue", 74, slot, value));
            Add(new ColorItem("Chocolate Brown", 96, slot, value));
            Add(new ColorItem("Bison Brown", 101, slot, value));
            Add(new ColorItem("Creeen Brown", 95, slot, value));
            Add(new ColorItem("Feltzer Brown", 94, slot, value));
            Add(new ColorItem("Maple Brown", 97, slot, value));
            Add(new ColorItem("Beechwood Brown", 103, slot, value));
            Add(new ColorItem("Sienna Brown", 104, slot, value));
            Add(new ColorItem("Saddle Brown", 98, slot, value));
            Add(new ColorItem("Moss Brown", 100, slot, value));
            Add(new ColorItem("Woodbeech Brown", 102, slot, value));
            Add(new ColorItem("Straw Brown", 99, slot, value));
            Add(new ColorItem("Sandy Brown", 105, slot, value));
            Add(new ColorItem("Bleached Brown", 106, slot, value));
            Add(new ColorItem("Schafter Purple", 71, slot, value));
            Add(new ColorItem("Spinnaker Purple", 72, slot, value));
            Add(new ColorItem("Midnight Purple", 142, slot, value));
            Add(new ColorItem("Bright Purple", 145, slot, value));
            Add(new ColorItem("Cream", 107, slot, value));
            Add(new ColorItem("Ice White", 111, slot, value));
            Add(new ColorItem("Frost White", 112, slot, value));
        }

        #endregion
    }
}
