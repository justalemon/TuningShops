using GTA.Native;
using GTA;
using LemonUI.Menus;
using System;

namespace TuningShops.Items
{
    /// <summary>
    /// The item that changes the current headlights.
    /// </summary>
    public class HeadlightsItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// If xenon should be turned on.
        /// </summary>
        public bool Xenon { get; }
        /// <summary>
        /// The color of the Xenon headlighs.
        /// </summary>
        public int Color { get; }

        #endregion

        #region Constructors

        public HeadlightsItem(string label, bool xenon, int color) : base(Function.Call<string>(Hash._GET_LABEL_TEXT, label))
        {
            Xenon = xenon;
            Color = color;

            Activated += ItemHeadlights_Activated;
        }

        #endregion

        #region Events

        private void ItemHeadlights_Activated(object sender, EventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            Function.Call(Hash.TOGGLE_VEHICLE_MOD, vehicle, 22, Xenon);

            if (!Xenon)
            {
                return;
            }

            Function.Call(Hash._SET_VEHICLE_XENON_LIGHTS_COLOR, vehicle, Color);
        }

        #endregion
    }
}
