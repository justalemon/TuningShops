using GTA;
using GTA.Native;
using LemonUI.Menus;
using System.Collections.Generic;
using System.ComponentModel;

namespace TuningShops.Menus
{
    /// <summary>
    /// The main menu used for changing the tuning options.
    /// </summary>
    public class MenuMain : NativeMenu
    {
        #region Properties

        /// <summary>
        /// The submenus that change the vehicle mods.
        /// </summary>
        public Dictionary<int, NativeSubmenuItem> Menus { get; } = new Dictionary<int, NativeSubmenuItem>();

        #endregion

        #region Constructors

        public MenuMain() : base("", "Tuning")
        {
            for (int i = 0; i < 50; i++)
            {
                NativeSubmenuItem sub;

                if (i >= 17 && i <= 22)
                {
                    sub = new NativeSubmenuItem(new MenuToggle(i), this);

                }
                else
                {
                    sub = new NativeSubmenuItem(new MenuMods(i), this);
                }

                Menus[i] = sub;
            }

            Opening += MenuTuning_Opening;
        }

        #endregion

        #region Events

        private void MenuTuning_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            for (int i = 0; i < 50; i++)
            {
                if (Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, i) > 0 || (i >= 17 && i <= 22))
                {
                    Add(Menus[i]);
                }
            }
        }

        #endregion
    }
}
