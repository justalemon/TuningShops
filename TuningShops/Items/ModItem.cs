﻿namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select Los Santos Customs modifications.
    /// </summary>
    public class ModItem : CoreItem
    {
        #region Constructor

        public ModItem(int index, string name) : base(index, name, "", 0)  // TODO: Make Price Calculations
        {
        }

        #endregion
    }
}