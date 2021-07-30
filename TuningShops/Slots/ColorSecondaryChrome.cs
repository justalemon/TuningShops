using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Chrome colors to the secondary slot.
    /// </summary>
    public class ColorSecondaryChrome : ColorChrome
    {
        #region Constructor

        public ColorSecondaryChrome() : base(ColorSlot.Secondary, 1400)
        {
        }

        #endregion
    }
}
