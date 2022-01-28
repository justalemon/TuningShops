using GTA;
using GTA.Native;
using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// The slot used for the color.
    /// </summary>
    internal enum ColorSlot
    {
        Primary,
        Secondary,
        Pearlescent,
        Wheels,
    }

    /// <summary>
    /// Represnets the item used to select a color.
    /// </summary>
    internal class ColorItem : StoreItem
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

        public ColorItem(string name, int id, ColorSlot slot, int value) : base(name, "", value)
        {
            Id = id;
            Slot = slot;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the color.
        /// </summary>
        public override void Apply()
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
                    Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, Id, secondary);
                    break;
                case ColorSlot.Secondary:
                    Function.Call(Hash.SET_VEHICLE_COLOURS, vehicle, primary, Id);
                    break;
                case ColorSlot.Pearlescent:
                    Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, Id, wheel);
                    break;
                case ColorSlot.Wheels:
                    Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, vehicle, pearlescent, Id);
                    break;
            }
        }

        #endregion
    }
}
