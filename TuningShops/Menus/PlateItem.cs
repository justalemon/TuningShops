﻿using GTA;
using GTA.Native;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Vehicle Plates.
    /// </summary>
    internal class PlateItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The index of the plate.
        /// </summary>
        public int Index { get; }

        #endregion

        #region Constructors

        public PlateItem(int index, string name, int price) : base(name, price)
        {
            Index = index;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the plate.
        /// </summary>
        public override void Apply()
        {
            Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Game.Player.Character.CurrentVehicle, Index);
        }

        #endregion
    }
}
