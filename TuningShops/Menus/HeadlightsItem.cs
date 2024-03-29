﻿using GTA.Native;
using GTA;
using System;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// The item that changes the current headlights.
    /// </summary>
    internal class HeadlightsItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The index of the Xenon color.
        /// </summary>
        public int Color { get; }
        /// <summary>
        /// If xenon should be turned on.
        /// </summary>
        public bool Xenon { get; }

        #endregion

        #region Constructors

        public HeadlightsItem(string label, bool xenon, int color) : base(Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, label), "", 1000)
        {
            Color = color;
            Xenon = xenon;
            Activated += ItemHeadlights_Activated;
        }

        #endregion

        #region Events

        private void ItemHeadlights_Activated(object sender, EventArgs e)
        {
            Apply();
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the configuration of the headlights.
        /// </summary>
        public override void Apply()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 22, Xenon);

            if (!Xenon)
            {
                return;
            }

            Function.Call(Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle, Color);  // Just in case
        }

        #endregion
    }
}
