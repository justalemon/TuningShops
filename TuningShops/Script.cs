using GTA;
using LemonUI;
using System;

namespace TuningShops
{
    /// <summary>
    /// The main class that handles the Tuning Shop features.
    /// </summary>
    public class TuningShops : Script
    {
        #region Fields

        private static readonly ObjectPool pool = new ObjectPool();

        #endregion

        #region Constructor

        public TuningShops()
        {
            Tick += TuningShops_Tick;
        }

        #endregion

        #region Events

        private void TuningShops_Tick(object sender, EventArgs e)
        {
            pool.Process();
        }

        #endregion
    }
}
