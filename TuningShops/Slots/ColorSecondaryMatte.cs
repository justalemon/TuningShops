using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Matte colors to the secondary slot.
    /// </summary>
    public class ColorSecondaryMatte : ColorMatte
    {
        #region Constructor

        public ColorSecondaryMatte() : base(ColorSlot.Secondary)
        {
        }

        #endregion
    }
}
