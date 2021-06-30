using GTA;
using GTA.Native;
using LemonUI.Menus;
using System.Collections.Generic;
using System.ComponentModel;

namespace TuningShops.Base
{
    /// <summary>
    /// Represents a basic Los Santos Customs slot.
    /// </summary>
    public class LSC : BaseType
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
        private Model lastModel = 0;

        #endregion

        #region Properties

        /// <summary>
        /// If this menu should be repopulate when being opened.
        /// </summary>
        public virtual bool Repopulate => true;
        /// <summary>
        /// The tuning slot associated with the menu.
        /// </summary>
        public int Slot { get; }

        #endregion

        #region Constructor

        public LSC(int slot, string name) : base(name)
        {
            Slot = slot;
            Opening += LSC_Opening;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle has enough slots to populate the menu.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if the vehicle has enough slots to be populated, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            return Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, Slot) > 0;
        }
        /// <summary>
        /// Gets the name of the mod on the specified index.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>The name of the mod or NULL if it was not found</returns>
        public string GetModName(int index)
        {
            string label;

            if (index == -1)
            {
                label = stockLabels.ContainsKey(Slot) ? stockLabels[Slot] : "";
            }
            else
            {
                label = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, Game.Player.Character.CurrentVehicle, Slot, index);
            }

            return Function.Call<string>(Hash._GET_LABEL_TEXT, label);
        }

        #endregion

        #region Events

        private void LSC_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            Model model = vehicle != null ? vehicle.Model : new Model(0);

            if (model == lastModel || !Repopulate)
            {
                return;
            }

            Clear();
            
            if (vehicle == null)
            {
                return;
            }

            for (int i = -1; i < Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, vehicle, Slot); i++)
            {
                Add(new NativeItem(GetModName(i)));
            }
        }

        #endregion
    }
}
