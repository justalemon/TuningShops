﻿using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Metals colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryMetals : ColorsMetals
    {
        #region Constructor

        public ColorPrimaryMetals() : base(ColorSlot.Primary, 650)
        {
        }

        #endregion
    }
}
