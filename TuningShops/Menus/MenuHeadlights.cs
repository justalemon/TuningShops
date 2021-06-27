using LemonUI.Menus;

namespace TuningShops.Menus
{
    /// <summary>
    /// Menu used for specifically changing Xenon Lights.
    /// </summary>
    public class MenuHeadlights : MenuBase
    {
        #region Constructors

        public MenuHeadlights() : base(22)
        {
            Add(new ItemHeadlights("CMOD_LGT_0", false, -1));
            Add(new ItemHeadlights("CMOD_LGT_1", true, -1));
            Add(new ItemHeadlights("CMOD_LGT_2", true, 0));
            Add(new ItemHeadlights("CMOD_LGT_3", true, 1));
            Add(new ItemHeadlights("CMOD_LGT_4", true, 2));
            Add(new ItemHeadlights("CMOD_LGT_5", true, 3));
            Add(new ItemHeadlights("CMOD_LGT_6", true, 4));
            Add(new ItemHeadlights("CMOD_LGT_7", true, 5));
            Add(new ItemHeadlights("CMOD_LGT_8", true, 7));
            Add(new ItemHeadlights("CMOD_LGT_9", true, 8));
            Add(new ItemHeadlights("CMOD_LGT_10", true, 9));
            Add(new ItemHeadlights("CMOD_LGT_11", true, 10));
            Add(new ItemHeadlights("CMOD_LGT_12", true, 11));
            Add(new ItemHeadlights("CMOD_LGT_13", true, 12));
        }

        #endregion
    }
}
