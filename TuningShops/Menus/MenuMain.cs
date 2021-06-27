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
                MenuBase menu;

                if (i == 22)
                {
                    menu = new MenuHeadlights();
                }
                else if (i >= 17 && i <= 22)
                {
                    menu = new MenuToggle(i);
                }
                else
                {
                    menu = new MenuMods(i);
                }

                Menus[i] = new NativeSubmenuItem(menu, this);
            }

            Opening += MenuTuning_Opening;
        }

        #endregion

        #region Events

        private void MenuTuning_Opening(object sender, CancelEventArgs e)
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            for (int i = 0; i < 50; i++)
            {
                if (Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, i) > 0 || (i >= 17 && i <= 22))
                {
                    NativeSubmenuItem item = Menus[i];
                    MenuBase menu = item.Menu as MenuBase;
                    string name = Function.Call<string>(Hash.GET_MOD_SLOT_NAME, Game.Player.Character.CurrentVehicle, menu.Slot);
                    item.Title = name;
                    menu.Subtitle = name;
                    Add(item);
                }
            }
        }

        #endregion
    }
}
