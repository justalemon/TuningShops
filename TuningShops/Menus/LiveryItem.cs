using GTA;
using GTA.Native;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// A regular Los Santos Customs livery.
    /// </summary>
    internal class LiveryItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The index of the Livery.
        /// </summary>
        public int Index { get; }

        #endregion

        #region Constructors

        public LiveryItem(int index, string name, int price) : base(name, price)
        {
            Index = index;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the livery.
        /// </summary>
        public override void Apply()
        {
            Function.Call(Hash.SET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle, Index);
        }

        #endregion
    }
}
