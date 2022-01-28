using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Chrome colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryChrome : ColorChrome
    {
        #region Constructor

        public ColorPrimaryChrome() : base(ColorSlot.Primary, 1200)
        {
        }

        #endregion
    }
}
