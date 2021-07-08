using GTA;
using LemonUI.Elements;
using LemonUI.Menus;
using System.Collections.Generic;
using System.ComponentModel;
using TuningShops.Core;

namespace TuningShops
{
    /// <summary>
    /// Represents a main menu in a specific location.
    /// </summary>
    public class MainMenu : NativeMenu
    {
        #region Fields

        private readonly List<BaseType> menus = new List<BaseType>();
        private Model lastModel = 0;

        #endregion

        #region Constructor

        public MainMenu(ShopLocation location, ScaledTexture texture) : base("", location.Name)
        {
            Banner = texture;
            UseMouse = false;
            Opening += MainMenu_Opening;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Adds a specific menu as part of this location.
        /// </summary>
        /// <param name="menu">The menu to add.</param>
        public void AddMenu(BaseType menu)
        {
            if (menus.Contains(menu))
            {
                return;
            }

            menus.Add(menu);
        }

        #endregion

        #region Events

        private void MainMenu_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            Model model = vehicle != null ? vehicle.Model : new Model(0);

            if (model == lastModel)
            {
                return;
            }

            Clear();

            if (vehicle == null)
            {
                return;
            }

            foreach (BaseType menu in menus)
            {
                if (menu.CanUse(vehicle))
                {
                    AddSubMenu(menu);
                }
            }

            lastModel = model;
        }

        #endregion
    }
}
