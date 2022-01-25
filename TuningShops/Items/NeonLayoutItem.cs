using System.Collections.Generic;

namespace TuningShops.Items
{
    /// <summary>
    /// The different layours offered in GTA V.
    /// </summary>
    internal enum NeonLayout
    {
        None,
        Front,
        Back,
        Sides,
        FrontAndBack,
        FrontAndSides,
        BackAndSides,
        FrontBackAndSides,
    }

    /// <summary>
    /// The item used to select the layout of the player's vehicle.
    /// </summary>
    internal class NeonLayoutItem : CoreItem
    {
        #region Fields

        internal static readonly Dictionary<NeonLayout, string> names = new Dictionary<NeonLayout, string>()
        {
            { NeonLayout.FrontAndBack, "Front and Back" },
            { NeonLayout.FrontAndSides, "Front and Sides" },
            { NeonLayout.BackAndSides, "Back and Sides" },
            { NeonLayout.FrontBackAndSides, "Front, Back and Sides" },
        };
        internal static readonly Dictionary<NeonLayout, int> values = new Dictionary<NeonLayout, int>()
        {
            { NeonLayout.None, 100 },
            { NeonLayout.Back, 1000 },
            { NeonLayout.Sides, 1250 },
            { NeonLayout.FrontAndBack, 1800 },
            { NeonLayout.FrontAndSides, 2000 },
            { NeonLayout.BackAndSides, 2000 },
            { NeonLayout.FrontBackAndSides, 3000 },
        };

        #endregion

        #region Constructors

        public NeonLayoutItem(NeonLayout layout) : base((int)layout, names.ContainsKey(layout) ? names[layout] : names.ToString(), "", values[layout])
        {
        }

        #endregion
    }
}
