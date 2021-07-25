using GTA;
using LemonUI.Menus;
using System.ComponentModel;
using TuningShops.Cameras;

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
        /// Selets the currently used modification by the vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        public abstract void SelectCurrent(Vehicle vehicle);
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

            CameraManager.Get(this).Create(vehicle);

            if (vehicle == null)
            {
                Clear();
                lastModel = model;
                return;
            }

            if (model != lastModel)
            {
                Repopulate();
                lastModel = model;
            }

            SelectCurrent(vehicle);
        }

        #endregion
    }
}
