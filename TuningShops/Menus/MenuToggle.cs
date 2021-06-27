using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using System.ComponentModel;

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

        public MenuToggle(int slot) : base(Function.Call<string>(Hash.GET_MOD_SLOT_NAME, Game.Player.Character.CurrentVehicle, slot))
        {
            Slot = slot;
            Opening += MenuToggle_Opening;
        }

        #endregion

        #region Events

        private void MenuToggle_Opening(object sender, CancelEventArgs e)
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }
            
            int count = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, Slot);

            for (int i = 0; i < count; i++)
            {
                Add(new ItemSwap(Slot, i));
            }
        }

        #endregion
    }
}
