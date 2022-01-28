using GTA;
using LemonUI.Elements;
using LemonUI.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TuningShops.Cameras;
using TuningShops.Core;
using TuningShops.Overrides;

namespace TuningShops.Locations
{
    /// <summary>
    /// Represents a main menu in a specific location.
    /// </summary>
    internal class MainMenu : NativeMenu
    {
        #region Fields

        private readonly List<ModificationSlot> menus = new List<ModificationSlot>();
        private Location location;
        private Model lastModel = 0;

        #endregion

        #region Constructor

        public MainMenu(Location location, ScaledTexture texture) : base("", location.Name)
        {
            this.location = location;
            Banner = texture;
            CloseOnInvalidClick = false;
            Opening += MainMenu_Opening;
            Shown += MainMenu_Shown;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Adds a specific menu as part of this location.
        /// </summary>
        /// <param name="menu">The menu to add.</param>
        public void AddMenu(ModificationSlot menu)
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

            if (model == lastModel)
            {
                return;
            }

            Clear();
            foreach (ModificationSlot menu in menus)
            {
                if (menu.CanBeUsed)
                {
                    if (OverrideManager.GetName(menu.GetType().FullName, model, out string name))
                    {
                        menu.Subtitle = name;
                    }
                    else
                    {
                        menu.Subtitle = menu.Name;
                    }

                    AddSubMenu(menu);
                }
            }

            lastModel = model;
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            CameraManager.Get(Guid.Empty).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
