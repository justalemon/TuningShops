using GTA;
using GTA.Native;
using System;
using TuningShops.Core;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// The base liveries on the menu.
    /// </summary>
    internal class Liveries : ModificationSlot<int>
    {
        #region Properties

        /// <summary>
        /// The current Livery index.
        /// </summary>
        public override int CurrentModification
        {
            get => Function.Call<int>(Hash.GET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle);
            set => Function.Call(Hash.SET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle, value);
        }
        /// <inheritdoc/>
        public override bool CanBeUsed => Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, Game.Player.Character.CurrentVehicle) > 0;

        #endregion

        #region Constructor

        public Liveries() : base("Liveries")
        {
        }

        #endregion

        #region Functions

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
                Add(new LiveryItem(i, Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, label), (int)Math.Ceiling(200 * ((i + 1) * 1.1f))));
            }
        }
        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            SelectedIndex = Function.Call<int>(Hash.GET_VEHICLE_LIVERY, Game.Player.Character.CurrentVehicle) + 1;
            UpdateBadges();
        }

        #endregion
    }
}
