using System.ComponentModel;
using GTA;
using GTA.Native;
using TuningShops.Menus;

namespace TuningShops.Slots
{
    /// <summary>
    /// The wheels (front wheel on a Bike) menu option.
    /// </summary>
    internal class LSCWheels : LosSantosCustoms
    {
        #region Fields

        private int lastWheelType = -1;
        
        #endregion
        
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

                return base.CanBeUsed && !vehicle.Model.IsBike && vehicle.Wheels.Count > 0;
            }
        }

        #endregion

        #region Constructor

        public LSCWheels() : base(23, "Wheels")
        {
            Opening += OnOpening;
        }
        
        #endregion
        
        #region Event Functions

        private void OnOpening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }
            
            int wheelType = Function.Call<int>(Hash.GET_VEHICLE_WHEEL_TYPE, vehicle.Handle);

            if (lastWheelType == wheelType)
            {
                return;
            }
            
            lastWheelType = wheelType;
            Repopulate();
        }

        #endregion
    }
}
