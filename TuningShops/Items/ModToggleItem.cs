using GTA;
using GTA.Native;
using System;
using TuningShops.Core;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to toggle Los Santos Customs modifications.
    /// </summary>
    internal class ModToggleItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The slot that this item toggles.
        /// </summary>
        public int Slot { get; }
        /// <summary>
        /// The activation set by this item.
        /// </summary>
        public bool Activation { get; }

        #endregion

        #region Constructors

        public ModToggleItem(int slot, bool activation, string name, int price) : base(name, price)
        {
            Slot = slot;
            Activation = activation;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the mod toggle.
        /// </summary>
        public override void Apply()
        {
            Function.Call(Hash.TOGGLE_VEHICLE_MOD, Game.Player.Character.CurrentVehicle, 18, Activation);
        }

        #endregion
    }
}
