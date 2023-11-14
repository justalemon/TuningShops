using GTA;
using GTA.Native;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using LemonUI.Menus;
using TuningShops.Core;
using TuningShops.Menus;
using Color = System.Drawing.Color;

namespace TuningShops.Slots
{
    /// <summary>
    /// Option to change the color of the Neon.
    /// </summary>
    internal class NeonColor : ModificationSlot<Color>
    {
        #region Fields

        private static readonly OrderedDictionary colors = new OrderedDictionary()
        {
            { "White", Color.FromArgb(222, 222, 255) },
            { "Blue", Color.FromArgb(2, 21, 255) },
            { "Electric Blue", Color.FromArgb(3, 83, 255) },
            { "Mint Green", Color.FromArgb(0, 255, 140) },
            { "Lime Green", Color.FromArgb(94, 255, 1) },
            { "Yellow", Color.FromArgb(255, 255, 0) },
            { "Golden Shower", Color.FromArgb(255, 150, 5) },
            { "Orange", Color.FromArgb(255, 62, 0) },
            { "Red", Color.FromArgb(255, 1, 1) },
            { "Pony Pink", Color.FromArgb(255, 50, 100) },
            { "Hot Pink", Color.FromArgb(255, 5, 190) },
            { "Purple", Color.FromArgb(35, 1, 255) },
            { "Blacklight", Color.FromArgb(15, 3, 255) },
        };

        #endregion

        #region Properties

        /// <summary>
        /// The color currently set as the Neon Color.
        /// </summary>
        public override Color CurrentModification
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;

                unsafe
                {
                    Function.Call(Hash.GET_VEHICLE_NEON_COLOUR, Game.Player.Character.CurrentVehicle, &r, &g, &b);
                }

                return Color.FromArgb(r, g, b);
            }
            set
            {
                Function.Call(Hash.SET_VEHICLE_NEON_COLOUR, Game.Player.Character.CurrentVehicle, (int)value.R, (int)value.G, (int)value.B);
            }
        }

        #endregion

        #region Constructors

        public NeonColor() : base("Neon Color")
        {
            foreach (DictionaryEntry entry in colors)
            {
                string name = (string)entry.Key;
                Color color = (Color)entry.Value;
                Add(new NeonColorItem(color, name));
            }
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanBeUsed => Game.Player.Character.CurrentVehicle.Wheels.Count > 2;
        /// <inheritdoc/>
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
            
            int r, g, b;
            unsafe
            {
                Function.Call(Hash.GET_VEHICLE_NEON_COLOUR, vehicle.Handle, &r, &g, &b);
            }
            Color color = Color.FromArgb(r, g, b);

            NativeItem item = Items.FirstOrDefault(x => x is NeonColorItem colorItem && colorItem.Color == color);

            if (item != null)
            {
                SelectedItem = item;
            }
            
            UpdateBadges();
        }

        #endregion
    }
}
