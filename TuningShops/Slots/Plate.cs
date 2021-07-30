using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used to change the plate frame.
    /// </summary>
    public class Plate : BaseType
    {
        #region Properties

        /// <inheritdoc/>
        public override int ModValue
        {
            get => Function.Call<int>(Hash.GET_​VEHICLE_​NUMBER_​PLATE_​TEXT_​INDEX, Game.Player.Character.CurrentVehicle);
            set => Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Game.Player.Character.CurrentVehicle, value);
        }

        #endregion

        #region Constructor

        public Plate() : base("Plate")
        {
            for (int i = 0; i < Function.Call<int>(Hash.GET_NUMBER_OF_VEHICLE_NUMBER_PLATES); i++)
            {
                Add(new PlateItem(i));
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle takes a plate.
        /// </summary>
        public override bool CanUse(Vehicle vehicle) => vehicle.Bones.Contains("platelight");
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Repopulate()
        {
        }
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
            SelectedIndex = Function.Call<int>(Hash.GET_​VEHICLE_​NUMBER_​PLATE_​TEXT_​INDEX, vehicle);
        }

        #endregion

        #region Item

        /// <summary>
        /// Item used to select a plate.
        /// </summary>
        public class PlateItem : NativeItem
        {
            #region Properties

            /// <summary>
            /// The index of the plate.
            /// </summary>
            public int Index { get; }

            #endregion

            #region Constructor

            public PlateItem(int index) : base($"Plate {index + 1}")
            {
                Index = index;
                Activated += PlateItem_Activated;
            }

            #endregion

            #region Events

            private void PlateItem_Activated(object sender, EventArgs e)
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return;
                }

                Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, vehicle, Index);
            }

            #endregion
        }

        #endregion
    }
}
