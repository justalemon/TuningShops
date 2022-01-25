using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Metals colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryMetals : ColorMetals
    {
        #region Constructor

        public ColorPrimaryMetals() : base(ColorSlot.Primary, 650)
        {
        }

        #endregion
    }
}
