﻿namespace TuningShops.Core
{
    /// <summary>
    /// Sets a metal color.
    /// </summary>
    public class ColorMetals : Color
    {
        #region Constructor

        public ColorMetals(ColorSlot slot) : base(slot, "Metal")
        {
            Add(new ColorItem("Brushed Steel", 117, slot));
            Add(new ColorItem("Brushed Black Steel", 118, slot));
            Add(new ColorItem("Brushed Aluminum", 119, slot));
            Add(new ColorItem("Pure Gold", 158, slot));
            Add(new ColorItem("Brushed Gold", 159, slot));
        }

        #endregion
    }
}