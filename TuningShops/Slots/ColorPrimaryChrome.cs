using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Chrome colors to the primary slot.
    /// </summary>
    public class ColorPrimaryChrome : ColorChrome
    {
        #region Constructor

        public ColorPrimaryChrome() : base(ColorSlot.Primary, 1200)
        {
        }

        #endregion
    }
}
