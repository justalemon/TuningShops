﻿using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Matte colors to the primary slot.
    /// </summary>
    internal class ColorPrimaryMatte : ColorsMatte
    {
        #region Constructor

        public ColorPrimaryMatte() : base(ColorSlot.Primary, 1000)
        {
        }

        #endregion
    }
}
