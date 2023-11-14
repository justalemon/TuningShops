using GTA;
using GTA.Native;
using System;
using System.Collections.Specialized;
using TuningShops.Core;
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
            for (int i = 0; i < colors.Count; i++)
            {
                //Add(new CustomColorItem(i, Color.White, "", 650));
            }
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override bool CanBeUsed
        {
            get => throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
