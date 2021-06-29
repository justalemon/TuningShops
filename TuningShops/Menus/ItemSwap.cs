using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using System.Collections.Generic;

namespace TuningShops.Menus
{
    /// <summary>
    /// The item used to select a different item.
    /// </summary>
    public class ItemSwap : NativeItem
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

        /// <summary>
        /// The type of mod.
        /// </summary>
        public int Type { get; }
        /// <summary>
        /// The value of the mod for the type.
        /// </summary>
        public int Value { get; }

        #endregion

        #region Tools

        private static string GetName(int type, int value)
        {
            string label = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, Game.Player.Character.CurrentVehicle, type, value);

            if (string.IsNullOrWhiteSpace(label))
            {
                if (stockLabels.ContainsKey(type))
                {
                    label = stockLabels[type];
                }
            }

            return label;
        }

        #endregion

        #region Constructor

        public ItemSwap(int type, int value) : base(Function.Call<string>(Hash._GET_LABEL_TEXT, GetName(type, value)))
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
