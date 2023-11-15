using GTA;
using GTA.Native;
using LemonUI.Menus;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used for specifically changing Xenon Lights.
    /// </summary>
    internal class LSCHeadlights : LosSantosCustoms
    {
        #region Properties

        /// <inheritdoc/>
        public override bool CanBeUsed
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return false;
                }

                Model model = vehicle.Model;
                return model.IsVehicle || model.IsBike;
            }
        }
        /// <summary>
        /// The Current Xenon Color index.
        /// </summary>
        public override int CurrentModification
        {
            get
            {
                if (!Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, Game.Player.Character.CurrentVehicle, 22))
                {
                    return -2;
                }

                return Function.Call<int>(Hash.GET_VEHICLE_XENON_LIGHT_COLOR_INDEX, Game.Player.Character.CurrentVehicle);
            }
            set
            {
                foreach (NativeItem rawItem in Items)
                {
                    HeadlightsItem item = rawItem as HeadlightsItem;

                    if (item.Color == value)
                    {
                        item.Apply();
                    }
                }
            }
        }

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

        /// <inheritdoc/>
        public override unsafe void SelectCurrent()
        {
            if (!Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, Game.Player.Character.CurrentVehicle, 22))
            {
                SelectedIndex = 0;
                UpdateBadges();
            }

            int index = Function.Call<int>(Hash.GET_VEHICLE_XENON_LIGHT_COLOR_INDEX, Game.Player.Character.CurrentVehicle);

            foreach (NativeItem rawItem in Items)
            {
                HeadlightsItem item = (HeadlightsItem)rawItem;

                if (item.Color == index)
                {
                    SelectedItem = rawItem;
                    UpdateBadges();
                    return;
                }
            }

            SelectedIndex = 0;
            UpdateBadges(true);
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
