﻿using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Applies Wheel colors to the primary slot.
    /// </summary>
    public class ColorWheels : Core.ColorWheels
    {
        #region Constructor

        public ColorWheels() : base(ColorSlot.Wheels, 500)
        {
        }

        #endregion
    }
}
