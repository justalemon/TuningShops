using GTA;
using LemonUI.Elements;
using LemonUI.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Locations
{
    /// <summary>
    /// Represents a main menu in a specific location.
    /// </summary>
    public class Menu : NativeMenu
    {
        #region Fields

        private readonly List<BaseType> menus = new List<BaseType>();
        private Location location;
        private Model lastModel = 0;

        #endregion

        #region Constructor

        public Menu(Location location, ScaledTexture texture) : base("", location.Name)
        {
            this.location = location;
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

            if (vehicle == null)
            {
                Clear();
                return;
            }

            CameraManager.Get(Guid.Empty).Create(vehicle);

            if (model == lastModel)
            {
                return;
            }

            Clear();
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
