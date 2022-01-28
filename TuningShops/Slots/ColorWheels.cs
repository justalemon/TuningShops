using TuningShops.Menus;
using MenusColorWheels = TuningShops.Menus.ColorWheels;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Wheel colors to the primary slot.
    /// </summary>
    internal class ColorWheels : MenusColorWheels
    {
        #region Constructor

        public ColorWheels() : base(ColorSlot.Wheels, 500)
        {
        }

        #endregion
    }
}
