using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Base;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used for specifically changing Xenon Lights.
    /// </summary>
    public class LSCHeadlights : LSC
    {
        #region Properties

        /// <summary>
        /// If the menu should be repopulated.
        /// </summary>
        public override bool Repopulate => false;

        #endregion

        #region Constructors

        public LSCHeadlights() : base(22, "Headlights")
        {
            Add(new ItemHeadlights("CMOD_LGT_0", false, -1));
            Add(new ItemHeadlights("CMOD_LGT_1", true, -1));
            Add(new ItemHeadlights("CMOD_LGT_2", true, 0));
            Add(new ItemHeadlights("CMOD_LGT_3", true, 1));
            Add(new ItemHeadlights("CMOD_LGT_4", true, 2));
            Add(new ItemHeadlights("CMOD_LGT_5", true, 3));
            Add(new ItemHeadlights("CMOD_LGT_6", true, 4));
            Add(new ItemHeadlights("CMOD_LGT_7", true, 5));
            Add(new ItemHeadlights("CMOD_LGT_8", true, 6));
            Add(new ItemHeadlights("CMOD_LGT_9", true, 7));
            Add(new ItemHeadlights("CMOD_LGT_10", true, 8));
            Add(new ItemHeadlights("CMOD_LGT_11", true, 9));
            Add(new ItemHeadlights("CMOD_LGT_12", true, 10));
            Add(new ItemHeadlights("CMOD_LGT_13", true, 11));
            Add(new ItemHeadlights("CMOD_LGT_14", true, 12));
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

        #endregion

        #region Headlights Item

        /// <summary>
        /// The item that changes the current headlights.
        /// </summary>
        public class ItemHeadlights : NativeItem
        {
            #region Properties

            /// <summary>
            /// If xenon should be turned on.
            /// </summary>
            public bool Xenon { get; }
            /// <summary>
            /// The color of the Xenon headlighs.
            /// </summary>
            public int Color { get; }

            #endregion

            #region Constructors

            public ItemHeadlights(string label, bool xenon, int color) : base(Function.Call<string>(Hash._GET_LABEL_TEXT, label))
            {
                Xenon = xenon;
                Color = color;

                Activated += ItemHeadlights_Activated;
            }

            #endregion

            #region Events

            private void ItemHeadlights_Activated(object sender, EventArgs e)
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

                Function.Call(Hash._SET_VEHICLE_XENON_LIGHTS_COLOR, vehicle, Color);
            }

            #endregion
        }

        #endregion
    }
}
