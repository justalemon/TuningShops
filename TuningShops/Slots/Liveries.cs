﻿using GTA;
using GTA.Native;
using System;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// The base liveries on the menu.
    /// </summary>
    internal class Liveries : BaseType
    {
        #region Properties

        /// <inheritdoc/>
        public override int ModificationIndex
        {
            get => Function.Call<int>(Hash.GET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle);
            set => Function.Call(Hash.SET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle, value);
        }

        #endregion

        #region Constructor

        public Liveries() : base("Liveries")
        {
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle has liveries available.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if the vehicle has liveries available, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            return Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, vehicle) > 0;
        }
        /// <summary>
        /// Adds the list of Liveries to the menu.
        /// </summary>
        public override void Repopulate()
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            for (int i = -1; i < Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, vehicle); i++)
            {
                string label = i == -1 ? "NONE" : Function.Call<string>(Hash.GET_LIVERY_NAME, vehicle, i);
                Add(new CoreItem(i, Function.Call<string>(Hash._GET_LABEL_TEXT, label), "", GetPrice(i)));
            }
        }
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
            SelectedIndex = Function.Call<int>(Hash.GET_VEHICLE_LIVERY, vehicle) + 1;
            UpdateBadges();
        }
        /// <inheritdoc/>
        public override int GetPrice(int index)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return 0;
            }

            return (int)Math.Ceiling(200 * ((index + 1) * 1.1f));
        }

        #endregion
    }
}
