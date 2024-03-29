﻿using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Classic colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryClassic : ColorsClassic
    {
        #region Constructor

        public ColorSecondaryClassic() : base(ColorSlot.Secondary, "Classic", 400)
        {
        }

        #endregion
    }
}
