using GTA;
using GTA.Native;
using LemonUI.Menus;
using System.ComponentModel;

namespace TuningShops.Menus
{
    /// <summary>
    /// The menu that allows you to change the different mods of the vehicle.
    /// </summary>
    public class MenuMods : MenuBase
    {
        #region Fields

        private Model lastModel = 0;

        #endregion

        #region Constructors

        public MenuMods(int slot) : base(slot)
        {
            ItemCount = CountVisibility.Always;
            Opening += MenuMods_Opening;
        }

        #endregion

        #region Functions

        public void Repopulate()
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

        #region Events

        private void MenuMods_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            if (vehicle.Model != lastModel)
            {
                Repopulate();
                lastModel = vehicle.Model;
            }
        }

        #endregion
    }
}
