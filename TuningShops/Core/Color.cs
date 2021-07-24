using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Cameras;

namespace TuningShops.Core
{
    /// <summary>
    /// Represents the core for the color selection menus.
    /// </summary>
    public abstract class Color : BaseType
    {
        #region Constructor

        public Color(ColorSlot slot, string type) : base($"{slot} Color" + (string.IsNullOrWhiteSpace(type) ? "" : $": {type}"))
        {
            Opening += (sender, e) => CameraSet.General.Create(Game.Player.Character.CurrentVehicle);
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
        public class ColorItem : NativeItem
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

            public ColorItem(string name, int id, ColorSlot slot) : base(name)
            {
                Id = id;
                Slot = slot;
                Activated += ColorItem_Activated;
            }

            #endregion

            #region Events

            private void ColorItem_Activated(object sender, EventArgs e)
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (vehicle == null)
                {
                    return;
                }

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

        #endregion
    }
}
