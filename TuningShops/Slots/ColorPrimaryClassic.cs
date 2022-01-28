using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Classic colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryClassic : ColorsClassic
    {
        #region Constructor

        public ColorPrimaryClassic() : base(ColorSlot.Primary, "Classic", 400)
        {
        }

        #endregion
    }
}
