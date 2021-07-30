using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Matte colors to the primary slot.
    /// </summary>
    public class ColorPrimaryMatte : ColorMatte
    {
        #region Constructor

        public ColorPrimaryMatte() : base(ColorSlot.Primary, 1000)
        {
        }

        #endregion
    }
}
