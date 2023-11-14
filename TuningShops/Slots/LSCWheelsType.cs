using System.Linq;
using GTA;
using GTA.Native;
using LemonUI.Menus;
using TuningShops.Core;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// Item to change the type of wheels.
    /// </summary>
    internal class LSCWheelsType : ModificationSlot<int>
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
                return !model.IsMotorcycle && vehicle.Wheels.Count > 0;
            }
        }
        /// <inheritdoc/>
        public override int CurrentModification
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;
                return vehicle == null ? 0 : Function.Call<int>(Hash.GET_VEHICLE_WHEEL_TYPE, vehicle.Handle);
            }
            set
            {
                
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return;
                }

                Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, vehicle.Handle, value);
            }
        }

        #endregion

        #region Constructors

        public LSCWheelsType() : base("Wheels Type")
        {
            Add(new WheelsTypeItem(0, "Sport"));
            Add(new WheelsTypeItem(1, "Muscle"));
            Add(new WheelsTypeItem(2, "Lowrider"));
            Add(new WheelsTypeItem(3, "SUV"));
            Add(new WheelsTypeItem(4, "Offroad"));
            Add(new WheelsTypeItem(5, "Tuner"));
            Add(new WheelsTypeItem(7, "High End"));
        }

        #endregion

        #region Functions

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

            int index = CurrentModification;
            NativeItem item = Items.FirstOrDefault(x => x is WheelsTypeItem wheelsItem && wheelsItem.Type == index);
            
            GTA.UI.Screen.ShowSubtitle($"{index} {item}");

            if (item != null)
            {
                SelectedItem = item;
            }
            
            UpdateBadges();
        }

        #endregion
    }
}
