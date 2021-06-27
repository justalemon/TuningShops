using GTA;
using GTA.Native;
using LemonUI.Menus;

namespace TuningShops.Menus
{
    /// <summary>
    /// Menu used to toggle items on or off.
    /// </summary>
    public class MenuToggle : NativeMenu
    {
        #region Properties

        /// <summary>
        /// The slot managed by this menu.
        /// </summary>
        public int Slot { get; }

        #endregion

        #region Constructors

        public MenuToggle(int slot) : base("", Function.Call<string>(Hash.GET_MOD_SLOT_NAME, Game.Player.Character.CurrentVehicle, slot))
        {
            Slot = slot;

            Add(new ItemToggle(slot, false));
            Add(new ItemToggle(slot, true));
        }

        #endregion
    }
}
