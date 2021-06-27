using GTA;
using GTA.Native;
using LemonUI.Menus;

namespace TuningShops.Menus
{
    /// <summary>
    /// The base menu used for changing vehicle mods.
    /// </summary>
    public abstract class MenuBase : NativeMenu
    {
        #region Properties

        /// <summary>
        /// The slot managed by this menu.
        /// </summary>
        public int Slot { get; }

        #endregion

        #region Constructors

        public MenuBase(int slot) : base("", "")
        {
            Slot = slot;
        }

        #endregion
    }
}
