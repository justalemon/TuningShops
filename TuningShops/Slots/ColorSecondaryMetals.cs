﻿using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Metals colors to the secondary slot.
    /// </summary>
    internal class ColorSecondaryMetals : ColorsMetals
    {
        #region Constructor

        public ColorSecondaryMetals() : base(ColorSlot.Secondary, 650)
        {
        }

        #endregion
    }
}
