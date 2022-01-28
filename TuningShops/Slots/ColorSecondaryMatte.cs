using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Matte colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryMatte : ColorsMatte
    {
        #region Constructor

        public ColorSecondaryMatte() : base(ColorSlot.Secondary, 1000)
        {
        }

        #endregion
    }
}
