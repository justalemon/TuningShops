using GTA;
using GTA.Native;
using TuningShops.Core;

namespace TuningShops.Items
{
    /// <summary>
    /// The item used to select Los Santos Customs and Benny's Original Motor Works modifications.
    /// </summary>
    public class ModIndexItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The slot of the mod.
        /// </summary>
        public int Slot { get; }
        /// <summary>
        /// The index of the mod.
        /// </summary>
        public int Index { get; }

        #endregion

        #region Constructor

        public ModIndexItem(int slot, int index, string name, int price) : base(name, "", price)
        {
            Slot = slot;
            Index = index;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the modification item.
        /// </summary>
        public override void Apply()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            Function.Call(Hash.SET_​VEHICLE_​MOD_​KIT, vehicle, 0);
            Function.Call(Hash.SET_VEHICLE_MOD, vehicle, Slot, Index, false);
        }

        #endregion
    }
}
