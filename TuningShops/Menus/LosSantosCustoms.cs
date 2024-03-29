﻿using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Represents a basic Los Santos Customs or Benny's Original Motor Works slot.
    /// </summary>
    public abstract class LosSantosCustoms : ModificationSlot<int>
    {
        #region Fields

        private static readonly Dictionary<int, string> stockLabels = new Dictionary<int, string>()
        {
            // LSC
            { 0, "CMOD_SPO_0" },
            { 1, "CMOD_BUM_0" },
            { 2, "CMOD_BUM_3" },
            { 3, "CMOD_SKI_0" },
            { 4, "CMOD_EXH_0" },
            { 5, "CMOD_DEF_RC" },  // Not sure
            { 6, "CMOD_GRL_0" },
            { 7, "CMOD_BON_0" },
            { 8, "CMOD_DEF_WG" },
            { 9, "" },
            { 10, "CMOD_ROF_0" },
            { 11, "" },
            { 12, "collision_9ld0k5x" },
            { 13, "" },
            { 14, "CMOD_HRN_0" },
            { 15, "CMOD_SUS_0" },
            { 16, "" },
            { 17, "" },  // Unknown
            { 18, "CMOD_TUR_0" },
            { 19, "" },  // Unknown
            { 20, "CMOD_TYR_3" },
            { 21, "" },  // Unknown
            { 22, "CMOD_LGT_0" },
            { 23, "CMOD_WHE_0" },
            { 24, "CMOD_WHE_B_0" },
            // Benny's
            { 25, "NONE" },  // Check for collisions instead of using generic
            { 26, "NONE" },  // Ditto
            { 27, "CMOD_DEF_TRIM" },
            { 28, "NONE" },  // Ditto
            { 29, "NONE" },  // Ditto
            { 30, "CMOD_DEF_DIAL" },
            { 31, "NONE" },  // Ditto
            { 32, "NONE" },  // Ditto
            { 33, "CMOD_DEF_WHE" },
            { 34, "NONE" },  // Ditto
            { 35, "NONE" },  // Ditto
            { 36, "NONE" },  // Ditto
            { 37, "NONE" },  // Ditto
            { 38, "" },  // Hydraulics, Unsuported in SP AFAIK
            { 39, "NONE" },  // Ditto
            { 40, "CMOD_AIR_STOCK" },
            { 41, "CMOD_COL5_41" },
            { 42, "NONE" },  // Ditto
            { 43, "NONE" },  // Ditto
            { 44, "NONE" },  // Ditto
            { 45, "NONE" },  // Ditto
            { 46, "" },  // Windows, unknown if is Tint or actual Windows
            { 47, "" },  // Unknown
            { 48, "NONE" },  // Ditto
        };

        #endregion

        #region Properties

        /// <inheritdoc/>
        public override int CurrentModification
        {
            get => Function.Call<int>(Hash.GET_VEHICLE_MOD, Game.Player.Character.CurrentVehicle, Slot);
            set
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);
                Function.Call(Hash.SET_VEHICLE_MOD, vehicle, Slot, value, false);
            }
        }
        /// <inheritdoc/>
        public override bool CanBeUsed => Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, Game.Player.Character.CurrentVehicle, Slot) > 0;
        /// <summary>
        /// The tuning slot associated with the menu.
        /// </summary>
        public int Slot { get; }

        #endregion

        #region Constructor

        public LosSantosCustoms(int slot, string name) : base(name)
        {
            Slot = slot;
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            SelectedIndex = Function.Call<int>(Hash.GET_VEHICLE_MOD, Game.Player.Character.CurrentVehicle, Slot) + 1;
            UpdateBadges();
        }
        /// <summary>
        /// Populates the menu with the items based on the mod slot.
        /// </summary>
        public override void Repopulate()
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            for (int i = -1; i < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, Slot); i++)
            {
                Add(new ModIndexItem(Slot, i, GetModName(i), i == -1 ? 200 : (int)Math.Ceiling(200 * ((i + 1) * 2.1f))));
            }
        }
        /// <summary>
        /// Gets the name of the mod on the specified index.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>The name of the mod or NULL if it was not found</returns>
        public string GetModName(int index)
        {
            if (Slot == 11)
            {
                switch (index)
                {
                    case -1: return "Stock Engine";
                    case 0: return "EMS Upgrade, Level 1";
                    case 1: return "EMS Upgrade, Level 2";
                    case 2: return "EMS Upgrade, Level 3";
                    case 3: return "EMS Upgrade, Level 4";
                }
            }
            else if (Slot == 12)
            {
                switch (index)
                {
                    case -1: return "Stock Brakes";
                    case 0: return "Street Brakes";
                    case 1: return "Sport Brakes";
                    case 2: return "Race Brakes";
                }
            }
            else if (Slot == 13)
            {
                switch (index)
                {
                    case -1: return "Stock Transmission";
                    case 0: return "Street Transmission";
                    case 1: return "Sport Transmission";
                    case 2: return "Race Transmission";
                    case 3: return "Super Transmission";
                }
            }
            else if (Slot == 15)
            {
                switch (index)
                {
                    case -1: return "Stock Suspension";
                    case 0: return "Lowered Suspension";
                    case 1: return "Street Suspension";
                    case 2: return "Sport Suspension";
                    case 3: return "Competition Suspension";
                    case 4: return "Race Suspension";
                }
            }
            else if (Slot == 16)
            {
                switch (index)
                {
                    case -1: return "None";
                    case 0: return "Armor Upgrade 20%";
                    case 1: return "Armor Upgrade 40%";
                    case 2: return "Armor Upgrade 60%";
                    case 3: return "Armor Upgrade 80%";
                    case 4: return "Armor Upgrade 100%";
                }
            }

            string label;

            if (index == -1)
            {
                label = stockLabels.ContainsKey(Slot) ? stockLabels[Slot] : "";
            }
            else
            {
                label = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, Game.Player.Character.CurrentVehicle, Slot, index);
            }

            return Function.Call<string>(Hash.GET_FILENAME_FOR_AUDIO_CONVERSATION, label);
        }

        #endregion
    }
}
