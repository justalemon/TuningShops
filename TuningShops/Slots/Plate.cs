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
        /// Returns true.
        /// </summary>
        public override bool CanUse(Vehicle vehicle) => true;
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Repopulate()
        {
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
