using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;

namespace TuningShops.Menus
{
    /// <summary>
    /// The item used to select a different item.
    /// </summary>
    public class ItemSwap : NativeItem
    {
        #region Properties

        /// <summary>
        /// The type of mod.
        /// </summary>
        public int Type { get; }
        /// <summary>
        /// The value of the mod for the type.
        /// </summary>
        public int Value { get; }

        #endregion

        #region Constructor

        public ItemSwap(int type, int value) : base(Function.Call<string>(Hash._GET_LABEL_TEXT, Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, Game.Player.Character.CurrentVehicle, type, value)))
        {
            Type = type;
            Value = value;

            Activated += ModSwapItem_Activated;
        }

        #endregion

        #region Events

        private void ModSwapItem_Activated(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.SET_VEHICLE_MOD, vehicle, Type, Value, false);
        }

        #endregion
    }
}
