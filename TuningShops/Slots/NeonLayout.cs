using GTA;
using GTA.Native;
using System;
using TuningShops.Core;
using TuningShops.Menus;
using NeonLayoutEnum = TuningShops.Menus.NeonLayout;

namespace TuningShops.Slots
{
    /// <summary>
    /// The menu option to change the layout of the neon.
    /// </summary>
    internal class NeonLayout : ModificationSlot<NeonLayoutEnum>
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

                return vehicle.Wheels.Count >= 4;
            }
        }
        /// <inheritdoc/>
        public override NeonLayoutEnum CurrentModification
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                bool left = Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, vehicle, 0);
                bool right = Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, vehicle, 1);
                bool front = Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, vehicle, 2);
                bool back = Function.Call<bool>(Hash.GET_VEHICLE_NEON_ENABLED, vehicle, 3);

                if (!left && !right && !front && !back)
                {
                    return NeonLayoutEnum.None;
                }
                else if (!left && !right && front && !back)
                {
                    return NeonLayoutEnum.Front;
                }
                else if (!left && !right && !front && back)
                {
                    return NeonLayoutEnum.Back;
                }
                else if (left && right && !front && !back)
                {
                    return NeonLayoutEnum.Sides;
                }
                else if (!left && !right && front && back)
                {
                    return NeonLayoutEnum.FrontAndBack;
                }
                else if (left && right && front && !back)
                {
                    return NeonLayoutEnum.FrontAndSides;
                }
                else if (left && right && !front && back)
                {
                    return NeonLayoutEnum.BackAndSides;
                }
                else if (left && right && front && back)
                {
                    return NeonLayoutEnum.FrontBackAndSides;
                }
                else
                {
                    Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, true);
                    Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, true);
                    Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, true);
                    Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, true);
                    return NeonLayoutEnum.FrontBackAndSides;
                }
            }
            set
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                switch (value)
                {
                    case NeonLayoutEnum.None:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.Front:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.Back:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.Sides:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.FrontAndBack:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.FrontAndSides:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.BackAndSides:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, false);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.FrontBackAndSides:
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 0, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 1, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 2, true);
                        Function.Call(Hash.SET_VEHICLE_NEON_ENABLED, vehicle, 3, true);
                        break;
                }
            }
        }

        #endregion

        #region Constructor

        public NeonLayout() : base("Neon Layout")
        {
            foreach (NeonLayoutEnum layout in Enum.GetValues(typeof(NeonLayoutEnum)))
            {
                Add(new NeonLayoutItem(layout));
            }
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void SelectCurrent()
        {
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
