using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Matte colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryMatte : ColorMatte
    {
        #region Constructor

        public ColorPrimaryMatte() : base(ColorSlot.Primary, 1000)
        {
        }

        #endregion
    }
}
