using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;

namespace TuningShops.Menus
{
    /// <summary>
    /// Item used to set a mod on or off.
    /// </summary>
    public class ItemToggle : NativeItem
    {
        #region Properties

        /// <summary>
        /// The slot that gets toggled by this item.
        /// </summary>
        public int Slot { get; }
        /// <summary>
        /// The activation set by this item.
        /// </summary>
        public bool Activation { get; }

        #endregion

        #region Constructors

        public ItemToggle(int slot, bool activation) : base(activation ? "On" : "Off")  // TODO: Get this thing localized
        {
            Slot = slot;
            Activation = activation;

            Activated += ItemToggle_Activated;
        }

        #endregion

        #region Events

        private void ItemToggle_Activated(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, Slot, Activation);
        }

        #endregion
    }
}
