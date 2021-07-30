using GTA.Native;
using GTA;
using LemonUI.Menus;
using System;
using System.Drawing;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select the tire smoke options.
    /// </summary>
    public class TireSmokeItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// THe color of the tire smoke.
        /// </summary>
        public Color Color { get; }

        #endregion

        #region Constructor

        public TireSmokeItem(string text, Color color) : base($"{text} Tire Smoke")
        {
            Color = color;
        }

        #endregion
    }
}
