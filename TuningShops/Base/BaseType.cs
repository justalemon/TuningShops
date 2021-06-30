using GTA;
using LemonUI.Menus;

namespace TuningShops.Base
{
    /// <summary>
    /// Represents the basics for a Mod Slot Type.
    /// </summary>
    public abstract class BaseType : NativeMenu
    {
        #region Constructor

        public BaseType(string title) : base("", title)
        {
            UseMouse = false;
        }

        #endregion

        #region Functions

        /// <summary>
        /// If the specified vehicle can use the menu functions.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>true if the vehicle can use the options of the menu, false otherwise.</returns>
        public abstract bool CanUse(Vehicle vehicle);

        #endregion
    }
}
