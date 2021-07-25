using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using System.ComponentModel;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The base liveries on the menu.
    /// </summary>
    public class Liveries : BaseType
    {
        #region Constructor

        public Liveries() : base("Liveries")
        {
            Opening += (sender, e) => CameraManager.Get(Guid.Empty).Create(Game.Player.Character.CurrentVehicle);
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
                Add(new LiveryItem(i == -1 ? "NONE" : Function.Call<string>(Hash.GET_LIVERY_NAME, vehicle, i), i));
            }
        }
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
            SelectedIndex = Function.Call<int>(Hash.GET_VEHICLE_LIVERY, vehicle) + 1;
        }

        #endregion

        #region Item

        /// <summary>
        /// THe item used to enable a specific livery.
        /// </summary>
        public class LiveryItem : NativeItem
        {
            #region Properties

            /// <summary>
            /// The index of the livery.
            /// </summary>
            public int Index { get; }

            #endregion

            #region Constructor

            public LiveryItem(string label, int index) : base(Function.Call<string>(Hash._GET_LABEL_TEXT, label))
            {
                Index = index;
                Activated += LiveryItem_Activated;
            }

            #endregion

            #region Events

            private void LiveryItem_Activated(object sender, EventArgs e)
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return;
                }

                Function.Call(Hash.SET_VEHICLE_LIVERY, vehicle, Index);
            }

            #endregion
        }

        #endregion
    }
}
