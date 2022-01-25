using GTA;
using GTA.Native;
using System;
using TuningShops.Core;
using TuningShops.Items;
using NeonLayoutEnum = TuningShops.Items.NeonLayout;

namespace TuningShops.Slots
{
    /// <summary>
    /// The menu option to change the layout of the neon.
    /// </summary>
    internal class NeonLayout : BaseType
    {
        #region Properties

        /// <inheritdoc/>
        public override int ModificationIndex
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                bool left = Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0);
                bool right = Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1);
                bool front = Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2);
                bool back = Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3);

                if (!left && !right && !front && !back)
                {
                    return (int)NeonLayoutEnum.None;
                }
                else if (!left && !right && front && !back)
                {
                    return (int)NeonLayoutEnum.Front;
                }
                else if (!left && !right && !front && back)
                {
                    return (int)NeonLayoutEnum.Back;
                }
                else if (left && right && !front && !back)
                {
                    return (int)NeonLayoutEnum.Sides;
                }
                else if (!left && !right && front && back)
                {
                    return (int)NeonLayoutEnum.FrontAndBack;
                }
                else if (left && right && front && !back)
                {
                    return (int)NeonLayoutEnum.FrontAndSides;
                }
                else if (left && right && !front && back)
                {
                    return (int)NeonLayoutEnum.BackAndSides;
                }
                else if (left && right && front && back)
                {
                    return (int)NeonLayoutEnum.FrontBackAndSides;
                }
                else
                {
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                    return (int)NeonLayoutEnum.FrontBackAndSides;
                }
            }
            set
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                switch ((NeonLayoutEnum)value)
                {
                    case NeonLayoutEnum.None:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.Front:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.Back:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.Sides:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.FrontAndBack:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.FrontAndSides:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                        break;
                    case NeonLayoutEnum.BackAndSides:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                        break;
                    case NeonLayoutEnum.FrontBackAndSides:
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                        Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
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
        public override bool CanUse(Vehicle vehicle) => vehicle.Wheels.Count >= 4;
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }
        /// <inheritdoc/>
        public override int GetPrice(int index)
        {
            if (Items.Count >= index)
            {
                return 0;
            }

            return ((NeonLayoutItem)Items[index]).Value;
        }

        #endregion
    }
}
