namespace TuningShops.Menus
{
    /// <summary>
    /// Sets a classic color.
    /// </summary>
    internal abstract class ColorsClassic : Colors
    {
        #region Constructor

        public ColorsClassic(ColorSlot slot, string name, int value) : base(slot, name)
        {
            Add(new ColorsItem("Black", 0, slot, value));
            Add(new ColorsItem("Carbon Black", 147, slot, value));
            Add(new ColorsItem("Graphite", 1, slot, value));
            Add(new ColorsItem("Anthracite Black", 11, slot, value));
            Add(new ColorsItem("Black Steel", 2, slot, value));
            Add(new ColorsItem("Dark Steel", 3, slot, value));
            Add(new ColorsItem("Silver", 3, slot, value));
            Add(new ColorsItem("Bluish Silver", 5, slot, value));
            Add(new ColorsItem("Rolled Steel", 6, slot, value));
            Add(new ColorsItem("Shadow Silver", 7, slot, value));
            Add(new ColorsItem("Stone Silver", 8, slot, value));
            Add(new ColorsItem("Midnight Silver", 9, slot, value));
            Add(new ColorsItem("Cast Iron Silver", 10, slot, value));
            Add(new ColorsItem("Red", 27, slot, value));
            Add(new ColorsItem("Torino Red", 28, slot, value));
            Add(new ColorsItem("Formula Red", 29, slot, value));
            Add(new ColorsItem("Lava Red", 150, slot, value));
            Add(new ColorsItem("Blaze Red", 30, slot, value));
            Add(new ColorsItem("Grace Red", 31, slot, value));
            Add(new ColorsItem("Garnet Red", 32, slot, value));
            Add(new ColorsItem("Sunset Red", 33, slot, value));
            Add(new ColorsItem("Cabernet Red", 34, slot, value));
            Add(new ColorsItem("Wine Red", 143, slot, value));
            Add(new ColorsItem("Candy Red", 35, slot, value));
            Add(new ColorsItem("Hot Pink", 135, slot, value));
            Add(new ColorsItem("Pfsiter Pink", 137, slot, value));
            Add(new ColorsItem("Salmon Pink", 136, slot, value));
            Add(new ColorsItem("Sunrise Orange", 36, slot, value));
            Add(new ColorsItem("Orange", 38, slot, value));
            Add(new ColorsItem("Bright Orange", 138, slot, value));
            Add(new ColorsItem("Gold", 99, slot, value));
            Add(new ColorsItem("Bronze", 90, slot, value));
            Add(new ColorsItem("Yellow", 88, slot, value));
            Add(new ColorsItem("Race Yellow", 89, slot, value));
            Add(new ColorsItem("Dew Yellow", 91, slot, value));
            Add(new ColorsItem("Dark Green", 49, slot, value));
            Add(new ColorsItem("Racing Green", 50, slot, value));
            Add(new ColorsItem("Sea Green", 51, slot, value));
            Add(new ColorsItem("Olive Green", 52, slot, value));
            Add(new ColorsItem("Bright Green", 53, slot, value));
            Add(new ColorsItem("Gasoline Green", 54, slot, value));
            Add(new ColorsItem("Lime Green", 92, slot, value));
            Add(new ColorsItem("Midnight Blue", 141, slot, value));
            Add(new ColorsItem("Galaxy Blue", 61, slot, value));
            Add(new ColorsItem("Dark Blue", 62, slot, value));
            Add(new ColorsItem("Saxon Blue", 63, slot, value));
            Add(new ColorsItem("Blue", 64, slot, value));
            Add(new ColorsItem("Mariner Blue", 65, slot, value));
            Add(new ColorsItem("Harbor Blue", 66, slot, value));
            Add(new ColorsItem("Diamond Blue", 67, slot, value));
            Add(new ColorsItem("Surf Blue", 68, slot, value));
            Add(new ColorsItem("Nautical Blue", 69, slot, value));
            Add(new ColorsItem("Racing Blue", 73, slot, value));
            Add(new ColorsItem("Ultra Blue", 70, slot, value));
            Add(new ColorsItem("Light Blue", 74, slot, value));
            Add(new ColorsItem("Chocolate Brown", 96, slot, value));
            Add(new ColorsItem("Bison Brown", 101, slot, value));
            Add(new ColorsItem("Creeen Brown", 95, slot, value));
            Add(new ColorsItem("Feltzer Brown", 94, slot, value));
            Add(new ColorsItem("Maple Brown", 97, slot, value));
            Add(new ColorsItem("Beechwood Brown", 103, slot, value));
            Add(new ColorsItem("Sienna Brown", 104, slot, value));
            Add(new ColorsItem("Saddle Brown", 98, slot, value));
            Add(new ColorsItem("Moss Brown", 100, slot, value));
            Add(new ColorsItem("Woodbeech Brown", 102, slot, value));
            Add(new ColorsItem("Straw Brown", 99, slot, value));
            Add(new ColorsItem("Sandy Brown", 105, slot, value));
            Add(new ColorsItem("Bleached Brown", 106, slot, value));
            Add(new ColorsItem("Schafter Purple", 71, slot, value));
            Add(new ColorsItem("Spinnaker Purple", 72, slot, value));
            Add(new ColorsItem("Midnight Purple", 142, slot, value));
            Add(new ColorsItem("Bright Purple", 145, slot, value));
            Add(new ColorsItem("Cream", 107, slot, value));
            Add(new ColorsItem("Ice White", 111, slot, value));
            Add(new ColorsItem("Frost White", 112, slot, value));
        }

        #endregion
    }
}
