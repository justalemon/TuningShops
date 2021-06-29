using GTA;
using GTA.Native;
using LemonUI.Menus;
using System.Collections.Generic;
using System.ComponentModel;

namespace TuningShops.Menus
{
    /// <summary>
    /// The main menu used for changing the tuning options.
    /// </summary>
    public class MenuMain : NativeMenu
    {
        #region Fields

        private static readonly Dictionary<int, string> fieldNames = new Dictionary<int, string>()
        {
            // LSC
            { 0, "CMOD_MOD_SPO" },
            { 1, "CMOD_MOD_BUMF" },
            { 2, "CMOD_MOD_BUMR" },
            { 3, "CMOD_MOD_SKI" },
            { 4, "CMOD_MOD_MUF" },
            { 5, "" },  // Frame
            { 6, "CMOD_MOD_GRL" },
            { 7, "CMOD_MOD_HOD" },
            { 8, "CMOD_MOD_FEN" },
            { 9, "CMOD_MOD_FEN" },  // Right Fender
            { 10, "CMOD_MOD_ROF" },
            { 11, "CMOD_MOD_ENG2" },
            { 12, "CMOD_MOD_BRA" },
            { 13, "CMOD_MOD_TRN" },
            { 14, "CMOD_MOD_HRN" },
            { 15, "CMOD_MOD_SUS" },
            { 15, "CMOD_MOD_SUS" },
            { 16, "CMOD_MOD_ARM" },
            { 17, "" },  // Unknown
            { 18, "CMOD_MOD_TUR" },
            { 19, "" },  // Unknown
            { 20, "CMOD_MOD_TYR3" },
            { 21, "" },  // Unknown
            { 22, "CMOD_MOD_LGT" }, // Headlights, shown as Lights
            { 23, "CMOD_MOD_WHEM" },  // Front Wheels, shown as just Wheels for now
            { 24, "CMOD_WHE0_1" },  // Rear Wheels, shown as Rear Wheel
            // Benny's
            { 25, "CMM_MOD_S0" },
            { 26, "CMM_MOD_S1" },
            { 27, "CMM_MOD_S2" },
            { 28, "CMM_MOD_S3" },
            { 29, "CMM_MOD_S4" },
            { 30, "CMM_MOD_S5" },
            { 31, "CMM_MOD_S6" },
            { 32, "CMM_MOD_S7" },
            { 33, "CMM_MOD_S8" },
            { 34, "CMM_MOD_S9" },
            { 35, "CMM_MOD_S10" },
            { 36, "CMM_MOD_S11" },  // Internally known as Speakers
            { 37, "CMM_MOD_S12" },
            { 38, "CMM_MOD_S13" },
            { 39, "CMM_MOD_S14" },
            { 40, "CMM_MOD_S15" },
            { 41, "CMM_MOD_S16" },
            { 42, "CMM_MOD_S17" },
            { 43, "CMM_MOD_S18" },
            { 44, "CMM_MOD_S19" },
            { 45, "CMM_MOD_S20" },
            { 46, "CMM_MOD_S21" },  // Windows, shown as Doors
            { 47, "" },  // Unknown
            { 48, "CMM_MOD_S23" }
        };
        private Model lastModel = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The submenus that change the vehicle mods.
        /// </summary>
        public Dictionary<int, NativeSubmenuItem> Menus { get; } = new Dictionary<int, NativeSubmenuItem>();

        #endregion

        #region Constructors

        public MenuMain() : base("", "Tuning")
        {
            ItemCount = CountVisibility.Always;

            for (int i = 0; i < 50; i++)
            {
                MenuBase menu;

                if (i == 22)
                {
                    menu = new MenuHeadlights();
                }
                else if (i >= 17 && i <= 22)
                {
                    menu = new MenuToggle(i);
                }
                else
                {
                    menu = new MenuMods(i);
                }

                Menus[i] = new NativeSubmenuItem(menu, this);
            }

            Opening += MenuTuning_Opening;
        }

        #endregion

        #region Tools

        public static string GetSlotName(int slot, bool isBike)
        {
            if (fieldNames.ContainsKey(slot))
            {
                if (slot == 23)
                {
                    if (isBike)
                    {
                        return "CMOD_WHE0_0";
                    }
                    else
                    {
                        return "CMOD_MOD_WHEM";
                    }
                }
                else
                {
                    return fieldNames[slot];
                }
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region Functions

        public void Repopulate()
        {
            Clear();

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            for (int i = 0; i < 50; i++)
            {
                if (Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, i) > 0 || (i >= 17 && i <= 22))
                {
                    NativeSubmenuItem item = Menus[i];
                    MenuBase menu = item.Menu as MenuBase;
                    bool isBike = vehicle.Model.IsBike;

                    string name = Function.Call<string>(Hash._GET_LABEL_TEXT, GetSlotName(i, isBike));

#if DEBUG
                    name = $"{name} ({i})";
#endif

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        item.Title = name;
                        menu.Subtitle = name;
                    }

                    Add(item);
                }
            }
        }

        #endregion

        #region Events

        private void MenuTuning_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            if (vehicle.Model != lastModel)
            {
                Repopulate();
                lastModel = vehicle.Model;
            }
        }

        #endregion
    }
}
