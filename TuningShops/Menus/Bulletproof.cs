using GTA;
using GTA.Native;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Button used to enable and disable the bulletproof tires.
    /// </summary>
    internal class Bulletproof : StoreItem
    {
        #region Properties

        /// <summary>
        /// If this item activates or deactivates the bulletproof tires.
        /// </summary>
        public bool Activation { get; }

        #endregion

        #region Constructors

        public Bulletproof(bool activation) : base(activation ? "Bulletproof Tires" : "Standard Tires", activation ? 4000 : 350)
        {
            Activation = activation;
        }

        #endregion

        #region Functions

        public override void Apply()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, vehicle, Activation);
        }

        #endregion
    }
}
