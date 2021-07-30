using GTA;
using GTA.Native;
using System;

namespace TuningShops.Core
{
    /// <summary>
    /// Represents the core for the color selection menus.
    /// </summary>
    public abstract class Color : BaseType
    {
        #region Properties

        /// <inheritdoc/>
        public override int ModValue
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return 0;
                }

                int primary, secondary, pearlescent, wheel;
                unsafe
                {
                    Function.Call(Hash.GET_VEHICLE_COLOURS, vehicle, &primary, &secondary);
                    Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, vehicle, &pearlescent, &wheel);
                }

                switch (Slot)
                {
                    case ColorSlot.Primary:
                        return primary;
                    case ColorSlot.Secondary:
                        return secondary;
                    case ColorSlot.Pearlescent:
                        return pearlescent;
                    case ColorSlot.Wheels:
                        return wheel;
                    default:
                        throw new ArgumentException("The Slot is not valid!", nameof(Slot));
                }
            }
            set
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                Function.Call(Hash.SET_VEHICLE_MOD_KIT, vehicle, 0);

                int primary, secondary, pearlescent, wheel;
                unsafe
                {
                    Function.Call(Hash.GET_VEHICLE_COLOURS, vehicle, &primary, &secondary);
                    Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, vehicle, &pearlescent, &wheel);
                }

                switch (Slot)
                {
                    case ColorSlot.Primary:
                        Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, value, secondary);
                        break;
                    case ColorSlot.Secondary:
                        Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, primary, value);
                        break;
                    case ColorSlot.Pearlescent:
                        Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, value, wheel);
                        break;
                    case ColorSlot.Wheels:
                        Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, pearlescent, value);
                        break;
                }
            }
        }
        /// <summary>
        /// The color slot that this menu controls.
        /// </summary>
        public ColorSlot Slot { get; }

        #endregion

        #region Constructor

        public Color(ColorSlot slot, string type) : base($"{slot} Color" + (string.IsNullOrWhiteSpace(type) ? "" : $": {type}"))
        {
            Slot = slot;
        }

        #endregion

        #region Functions

        public override bool CanUse(Vehicle vehicle) => Function.Call<bool>(Hash.IS_​VEHICLE_​SPRAYABLE, vehicle);
        public override void Repopulate()
        {
        }
        public override void SelectCurrent(Vehicle vehicle)
        {
        }

        #endregion

        #region Item

        /// <summary>
        /// The slot used for the color.
        /// </summary>
        public enum ColorSlot
        {
            Primary,
            Secondary,
            Pearlescent,
            Wheels,
        }

        /// <summary>
        /// Represnets the item used to select a color.
        /// </summary>
        public class ColorItem : ModItem
        {
            #region Properties

            /// <summary>
            /// The ID of the color.
            /// </summary>
            public int Id { get; }
            /// <summary>
            /// The slot that this item corresponts to.
            /// </summary>
            public ColorSlot Slot { get; }

            #endregion

            #region Constructor

            public ColorItem(string name, int id, ColorSlot slot, int value) : base(id, name, "", value)
            {
                Id = id;
                Slot = slot;
            }

            #endregion
        }

        #endregion
    }
}
