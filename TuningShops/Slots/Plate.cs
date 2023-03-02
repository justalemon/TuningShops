using GTA;
using GTA.Native;
using TuningShops.Core;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used to change the plate frame.
    /// </summary>
    internal class Plate : ModificationSlot<int>
    {
        #region Properties

        /// <inheritdoc/>
        public override int CurrentModification
        {
            get => Function.Call<int>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Game.Player.Character.CurrentVehicle);
            set => Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, Game.Player.Character.CurrentVehicle, value);
        }

        #endregion

        #region Constructor

        public Plate() : base("Plate")
        {
            for (int i = 0; i < Function.Call<int>(Hash.GET_NUMBER_OF_VEHICLE_NUMBER_PLATES); i++)
            {
                Add(new PlateItem(i, $"Plate {i}", 500));
            }
        }

        #endregion

        #region Functions

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

                return vehicle.Bones.Contains("platelight");
            }
        }
        /// <summary>
        /// Does nothing.
        /// </summary>
        public override void Repopulate()
        {
        }
        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            SelectedIndex = Function.Call<int>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, vehicle);
            UpdateBadges();
        }

        #endregion
    }
}
