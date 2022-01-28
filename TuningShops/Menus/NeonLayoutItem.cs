using GTA;
using GTA.Native;
using System.Collections.Generic;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// The different layours offered in GTA V.
    /// </summary>
    internal enum NeonLayout
    {
        None,
        Front,
        Back,
        Sides,
        FrontAndBack,
        FrontAndSides,
        BackAndSides,
        FrontBackAndSides,
    }

    /// <summary>
    /// The item used to select the layout of the player's vehicle.
    /// </summary>
    internal class NeonLayoutItem : StoreItem
    {
        #region Fields

        internal static readonly Dictionary<NeonLayout, string> names = new Dictionary<NeonLayout, string>()
        {
            { NeonLayout.FrontAndBack, "Front and Back" },
            { NeonLayout.FrontAndSides, "Front and Sides" },
            { NeonLayout.BackAndSides, "Back and Sides" },
            { NeonLayout.FrontBackAndSides, "Front, Back and Sides" },
        };
        internal static readonly Dictionary<NeonLayout, int> values = new Dictionary<NeonLayout, int>()
        {
            { NeonLayout.None, 100 },
            { NeonLayout.Front, 100 },
            { NeonLayout.Back, 1000 },
            { NeonLayout.Sides, 1250 },
            { NeonLayout.FrontAndBack, 1800 },
            { NeonLayout.FrontAndSides, 2000 },
            { NeonLayout.BackAndSides, 2000 },
            { NeonLayout.FrontBackAndSides, 3000 },
        };

        #endregion

        #region Properties

        /// <summary>
        /// The NeonLayout managed by this item.
        /// </summary>
        public NeonLayout Layout { get; }

        #endregion

        #region Constructors

        public NeonLayoutItem(NeonLayout layout) : base(names.ContainsKey(layout) ? names[layout] : layout.ToString(), values[layout])
        {
            Layout = layout;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the neon layout.
        /// </summary>
        public override void Apply()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            switch (Layout)
            {
                case NeonLayout.None:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                    break;
                case NeonLayout.Front:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                    break;
                case NeonLayout.Back:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                    break;
                case NeonLayout.Sides:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                    break;
                case NeonLayout.FrontAndBack:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                    break;
                case NeonLayout.FrontAndSides:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, false);
                    break;
                case NeonLayout.BackAndSides:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, false);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                    break;
                case NeonLayout.FrontBackAndSides:
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 0, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 1, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 2, true);
                    Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, vehicle, 3, true);
                    break;
            }
        }

        #endregion
    }
}
