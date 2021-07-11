namespace TuningShops.Core
{
    /// <summary>
    /// Sets a classic color.
    /// </summary>
    public class ColorClassic : Color
    {
        #region Constructor

        public ColorClassic(ColorSlot slot) : base(slot, "Classic")
        {
            Add(new ColorItem("Black", 0, slot));
            Add(new ColorItem("Carbon Black", 147, slot));
            Add(new ColorItem("Graphite", 1, slot));
            Add(new ColorItem("Anthracite Black", 11, slot));
            Add(new ColorItem("Black Steel", 2, slot));
            Add(new ColorItem("Dark Steel", 3, slot));
            Add(new ColorItem("Silver", 3, slot));
            Add(new ColorItem("Bluish Silver", 5, slot));
            Add(new ColorItem("Rolled Steel", 6, slot));
            Add(new ColorItem("Shadow Silver", 7, slot));
            Add(new ColorItem("Stone Silver", 8, slot));
            Add(new ColorItem("Midnight Silver", 9, slot));
            Add(new ColorItem("Cast Iron Silver", 10, slot));
            Add(new ColorItem("Red", 27, slot));
            Add(new ColorItem("Torino Red", 28, slot));
            Add(new ColorItem("Formula Red", 29, slot));
            Add(new ColorItem("Lava Red", 150, slot));
            Add(new ColorItem("Blaze Red", 30, slot));
            Add(new ColorItem("Grace Red", 31, slot));
            Add(new ColorItem("Garnet Red", 32, slot));
            Add(new ColorItem("Sunset Red", 33, slot));
            Add(new ColorItem("Cabernet Red", 34, slot));
            Add(new ColorItem("Wine Red", 143, slot));
            Add(new ColorItem("Candy Red", 35, slot));
            Add(new ColorItem("Hot Pink", 135, slot));
            Add(new ColorItem("Pfsiter Pink", 137, slot));
            Add(new ColorItem("Salmon Pink", 136, slot));
            Add(new ColorItem("Sunrise Orange", 36, slot));
            Add(new ColorItem("Orange", 38, slot));
            Add(new ColorItem("Bright Orange", 138, slot));
            Add(new ColorItem("Gold", 99, slot));
            Add(new ColorItem("Bronze", 90, slot));
            Add(new ColorItem("Yellow", 88, slot));
            Add(new ColorItem("Race Yellow", 89, slot));
            Add(new ColorItem("Dew Yellow", 91, slot));
            Add(new ColorItem("Dark Green", 49, slot));
            Add(new ColorItem("Racing Green", 50, slot));
            Add(new ColorItem("Sea Green", 51, slot));
            Add(new ColorItem("Olive Green", 52, slot));
            Add(new ColorItem("Bright Green", 53, slot));
            Add(new ColorItem("Gasoline Green", 54, slot));
            Add(new ColorItem("Lime Green", 92, slot));
            Add(new ColorItem("Midnight Blue", 141, slot));
            Add(new ColorItem("Galaxy Blue", 61, slot));
            Add(new ColorItem("Dark Blue", 62, slot));
            Add(new ColorItem("Saxon Blue", 63, slot));
            Add(new ColorItem("Blue", 64, slot));
            Add(new ColorItem("Mariner Blue", 65, slot));
            Add(new ColorItem("Harbor Blue", 66, slot));
            Add(new ColorItem("Diamond Blue", 67, slot));
            Add(new ColorItem("Surf Blue", 68, slot));
            Add(new ColorItem("Nautical Blue", 69, slot));
            Add(new ColorItem("Racing Blue", 73, slot));
            Add(new ColorItem("Ultra Blue", 70, slot));
            Add(new ColorItem("Light Blue", 74, slot));
            Add(new ColorItem("Chocolate Brown", 96, slot));
            Add(new ColorItem("Bison Brown", 101, slot));
            Add(new ColorItem("Creeen Brown", 95, slot));
            Add(new ColorItem("Feltzer Brown", 94, slot));
            Add(new ColorItem("Maple Brown", 97, slot));
            Add(new ColorItem("Beechwood Brown", 103, slot));
            Add(new ColorItem("Sienna Brown", 104, slot));
            Add(new ColorItem("Saddle Brown", 98, slot));
            Add(new ColorItem("Moss Brown", 100, slot));
            Add(new ColorItem("Woodbeech Brown", 102, slot));
            Add(new ColorItem("Straw Brown", 99, slot));
            Add(new ColorItem("Sandy Brown", 105, slot));
            Add(new ColorItem("Bleached Brown", 106, slot));
            Add(new ColorItem("Schafter Purple", 71, slot));
            Add(new ColorItem("Spinnaker Purple", 72, slot));
            Add(new ColorItem("Midnight Purple", 142, slot));
            Add(new ColorItem("Bright Purple", 145, slot));
            Add(new ColorItem("Cream", 107, slot));
            Add(new ColorItem("Ice White", 111, slot));
            Add(new ColorItem("Frost White", 112, slot));
        }

        #endregion
    }
}
