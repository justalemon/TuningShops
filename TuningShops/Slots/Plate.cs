using GTA;
using GTA.Native;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used to change the plate frame.
    /// </summary>
    internal class Plate : BaseType
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
                Add(new CoreItem(i, $"Plate {i}", "", 500));
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
            UpdateBadges();
        }
        /// <inheritdoc/>
        public override int GetPrice(int index) => 0;

        #endregion
    }
}
