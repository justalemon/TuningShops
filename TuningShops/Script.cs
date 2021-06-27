using GTA;
using LemonUI;
using LemonUI.Menus;
using System;
using System.Collections.Generic;
using TuningShops.Menus;

namespace TuningShops
{
    /// <summary>
    /// The main class that handles the Tuning Shop features.
    /// </summary>
    public class TuningShops : Script
    {
        #region Fields

        private static readonly ObjectPool pool = new ObjectPool();
        private static readonly MenuMain main = new MenuMain();

        #endregion

        #region Constructor

        public TuningShops()
        {
            Tick += TuningShops_Tick;

            pool.Add(main);
            foreach (KeyValuePair<int, NativeSubmenuItem> pair in main.Menus)
            {
                pool.Add(pair.Value.Menu);
            }
        }

        #endregion

        #region Events

        private void TuningShops_Tick(object sender, EventArgs e)
        {
            if (Game.IsControlJustPressed(Control.MultiplayerInfo))
            {
                if (pool.AreAnyVisible)
                {
                    pool.HideAll();
                }
                else
                {
                    main.Visible = true;
                }
            }

            pool.Process();
        }

        #endregion
    }
}
