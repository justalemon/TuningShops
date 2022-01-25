using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Metals colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryMetals : ColorMetals
    {
        #region Constructor

        public ColorSecondaryMetals() : base(ColorSlot.Secondary, 650)
        {
        }

        #endregion
    }
}
