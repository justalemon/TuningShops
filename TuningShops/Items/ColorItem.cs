namespace TuningShops.Items
{
    /// <summary>
    /// The slot used for the color.
    /// </summary>
    internal enum ColorSlot
    {
        Primary,
        Secondary,
        Pearlescent,
        Wheels,
    }

    /// <summary>
    /// Represnets the item used to select a color.
    /// </summary>
    internal class ColorItem : CoreItem
    {
        #region Properties

        /// <summary>
        /// The ID of the color.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The slot that this item corresponts to.
        /// </summary>
        public ColorSlot Slot { get; }

        #endregion

        #region Constructor

        public ColorItem(string name, int id, ColorSlot slot, int value) : base(id, name, "", value)
        {
            Id = id;
            Slot = slot;
        }

        #endregion
    }
}
