using GTA;
using LemonUI.Menus;
using System.ComponentModel;

namespace TuningShops.Core
{
    /// <summary>
    /// Represents the basics for a Mod Slot Type.
    /// </summary>
    public abstract class BaseType : NativeMenu
    {
        #region Fields

        private Model lastModel = 0;

        #endregion

        #region Constructor

        public BaseType(string title) : base("", title)
        {
            UseMouse = false;
            Opening += BaseType_Opening;
        }

        #endregion

        #region Functions

        /// <summary>
        /// If the specified vehicle can use the menu functions.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>true if the vehicle can use the options of the menu, false otherwise.</returns>
        public abstract bool CanUse(Vehicle vehicle);
        /// <summary>
        /// Repopulates the number of menu items.
        /// </summary>
        public abstract void Repopulate();

        #endregion

        #region Events

        private void BaseType_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            Model model = vehicle != null ? vehicle.Model : new Model(0);

            if (model == lastModel)
            {
                return;
            }

            if (vehicle == null)
            {
                Clear();
                return;
            }

            Repopulate();
            lastModel = model;
        }

        #endregion
    }
}
