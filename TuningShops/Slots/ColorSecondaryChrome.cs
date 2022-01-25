using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Chrome colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryChrome : ColorChrome
    {
        #region Constructor

        public ColorSecondaryChrome() : base(ColorSlot.Secondary, 1400)
        {
        }

        #endregion
    }
}
