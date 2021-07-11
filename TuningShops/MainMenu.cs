using GTA;
using LemonUI.Elements;
using LemonUI.Menus;
using System;
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
        private ShopLocation location;
        private Model lastModel = 0;

        #endregion

        #region Constructor

        public MainMenu(ShopLocation location, ScaledTexture texture) : base("", location.Name)
        {
            this.location = location;
            Banner = texture;
            UseMouse = false;
            Opening += MainMenu_Opening;
            Closed += MainMenu_Closed;
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

            vehicle.PositionNoOffset = location.VehiclePos;
            vehicle.Heading = location.VehicleHeading;
            vehicle.IsPositionFrozen = true;

            foreach (BaseType menu in menus)
            {
                if (menu.CanUse(vehicle))
                {
                    AddSubMenu(menu);
                }
            }

            lastModel = model;
        }

        private void MainMenu_Closed(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (!TuningShops.pool.AreAnyVisible)
            {
                if (vehicle != null)
                {
                    vehicle.IsPositionFrozen = false;
                }
                lastModel = 0;
            }
        }

        #endregion
    }
}
