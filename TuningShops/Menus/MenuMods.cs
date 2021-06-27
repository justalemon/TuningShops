using GTA;
using GTA.Native;
using System.ComponentModel;

namespace TuningShops.Menus
{
    /// <summary>
    /// The menu that allows you to change the different mods of the vehicle.
    /// </summary>
    public class MenuMods : MenuBase
    {
        #region Constructors

        public MenuMods(int slot) : base(slot)
        {
            Opening += MenuMods_Opening;
        }

        #endregion

        #region Events

        private void MenuMods_Opening(object sender, CancelEventArgs e)
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            int count = Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, Slot);

            for (int i = -1; i < count; i++)
            {
                Add(new ItemSwap(Slot, i));
            }
        }

        #endregion
    }
}
