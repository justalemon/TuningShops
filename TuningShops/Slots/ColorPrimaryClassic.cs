using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Classic colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryClassic : ColorClassic
    {
        #region Constructor

        public ColorPrimaryClassic() : base(ColorSlot.Primary, "Classic", 400)
        {
        }

        #endregion
    }
}
