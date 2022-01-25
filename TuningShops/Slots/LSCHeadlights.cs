using GTA;
using GTA.Native;
using LemonUI.Menus;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used for specifically changing Xenon Lights.
    /// </summary>
    internal class LSCHeadlights : LosSantosCustoms
    {
        #region Properties

        /// <summary>
        /// The Current Xenon Color index.
        /// </summary>
        public override int ModValue
        {
            get
            {
                if (!Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, Game.Player.Character.CurrentVehicle, 22))
                {
                    return -2;
                }

                return Function.Call<int>(Hash._GET_VEHICLE_XENON_LIGHTS_COLOR, Game.Player.Character.CurrentVehicle);
            }
            set
            {
                foreach (NativeItem rawItem in Items)
                {
                    HeadlightsItem item = rawItem as HeadlightsItem;

                    if (item.Index == value)
                    {
                        item.Apply();
                    }
                }
            }
        }
        /// <summary>
        /// If the menu should be repopulated.
        /// </summary>
        public override bool ShouldRepopulate => false;

        #endregion

        #region Constructors

        public LSCHeadlights() : base(22, "Headlights")
        {
            Add(new HeadlightsItem("CMOD_LGT_0", false, -2));
            Add(new HeadlightsItem("CMOD_LGT_1", true, -1));
            Add(new HeadlightsItem("CMOD_LGT_2", true, 0));
            Add(new HeadlightsItem("CMOD_LGT_3", true, 1));
            Add(new HeadlightsItem("CMOD_LGT_4", true, 2));
            Add(new HeadlightsItem("CMOD_LGT_5", true, 3));
            Add(new HeadlightsItem("CMOD_LGT_6", true, 4));
            Add(new HeadlightsItem("CMOD_LGT_7", true, 5));
            Add(new HeadlightsItem("CMOD_LGT_8", true, 6));
            Add(new HeadlightsItem("CMOD_LGT_9", true, 7));
            Add(new HeadlightsItem("CMOD_LGT_10", true, 8));
            Add(new HeadlightsItem("CMOD_LGT_11", true, 9));
            Add(new HeadlightsItem("CMOD_LGT_12", true, 10));
            Add(new HeadlightsItem("CMOD_LGT_13", true, 11));
            Add(new HeadlightsItem("CMOD_LGT_14", true, 12));
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle can use the Headlights option.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if the vehicle can use headlights, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            Model model = vehicle.Model;
            return model.IsVehicle || model.IsBike;
        }
        /// <inheritdoc/>
        public override unsafe void SelectCurrent(Vehicle vehicle)
        {
            if (!Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, Game.Player.Character.CurrentVehicle, 22))
            {
                SelectedIndex = 0;
                UpdateBadges();
            }

            int index = Function.Call<int>(Hash._GET_VEHICLE_XENON_LIGHTS_COLOR, Game.Player.Character.CurrentVehicle);

            foreach (NativeItem rawItem in Items)
            {
                HeadlightsItem item = (HeadlightsItem)rawItem;

                if (item.Index == index)
                {
                    SelectedItem = rawItem;
                    UpdateBadges();
                    return;
                }
            }

            SelectedIndex = 0;
            UpdateBadges(true);
        }

        #endregion
    }
}
