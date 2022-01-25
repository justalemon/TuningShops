using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Classic colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryClassic : ColorClassic
    {
        #region Constructor

        public ColorSecondaryClassic() : base(ColorSlot.Secondary, "Classic", 400)
        {
        }

        #endregion
    }
}
