using GTA;
using GTA.Native;
using LemonUI.Menus;
using System;
using TuningShops.Locations;
using TuningShops.Menus;
using Color = System.Drawing.Color;

namespace TuningShops.Slots
{
    /// <summary>
    /// The tire smoke menu option.
    /// </summary>
    internal class LSCTireSmoke : LosSantosCustoms
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

                return vehicle.Wheels.Count > 0;
            }
        }
        /// <summary>
        /// The color present when the menu was opened.
        /// </summary>
        public Color ActiveColor { get; set; }

        #endregion

        #region Constructor

        public LSCTireSmoke() : base(20, "Tire Smoke")
        {
            Add(new TireSmokeItem("White", Color.FromArgb(255, 255, 255, 255), 1000));
            Add(new TireSmokeItem("Black", Color.FromArgb(255, 20, 20, 20), 1250));
            Add(new TireSmokeItem("Blue", Color.FromArgb(255, 0, 174, 239), 1500));
            Add(new TireSmokeItem("Yellow", Color.FromArgb(255, 252, 238, 0), 1750));
            Add(new TireSmokeItem("Purple", Color.FromArgb(255, 100, 79, 142), 1900));
            Add(new TireSmokeItem("Orange", Color.FromArgb(255, 255, 127, 0), 2000));
            Add(new TireSmokeItem("Green", Color.FromArgb(255, 102, 152, 104), 2150));
            Add(new TireSmokeItem("Red", Color.FromArgb(255, 255, 6, 6), 2250));
            Add(new TireSmokeItem("Pink", Color.FromArgb(255, 203, 54, 148), 2500));
            Add(new TireSmokeItem("Brown", Color.FromArgb(255, 180, 130, 97), 2500));
            Add(new TireSmokeItem("Patriot", Color.FromArgb(255, 0, 0, 0), 2500));

            Shown += LSCTireSmoke_Shown;
            ItemActivated += LSCTireSmoke_ItemActivated;
            Closed += LSCTireSmoke_Closed;
        }

        #endregion

        #region Events

        private void LSCTireSmoke_Shown(object sender, EventArgs e)
        {
            Ped ped = Game.Player.Character;
            Vehicle vehicle = ped.CurrentVehicle;

            int r, g, b;
            unsafe
            {
                Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, &r, &g, &b);
            }
            ActiveColor = Color.FromArgb(255, r, g ,b);

            Game.Player.CanControlCharacter = false;
            vehicle.IsPositionFrozen = false;
            vehicle.CanTiresBurst = false;
            Function.Call(Hash.TASK_VEHICLE_TEMP_ACTION, ped, vehicle, 30, 60 * 60 * 24);
        }
        private void LSCTireSmoke_ItemActivated(object sender, ItemActivatedArgs e)
        {
            TireSmokeItem item = e.Item as TireSmokeItem;

            if (item == null)
            {
                return;
            }

            ActiveColor = item.Color;
        }
        private void LSCTireSmoke_Closed(object sender, EventArgs e)
        {
            Ped ped = Game.Player.Character;
            Vehicle vehicle = ped.CurrentVehicle;

            Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, ActiveColor.R, ActiveColor.G, ActiveColor.B);

            Game.Player.CanControlCharacter = true;
            vehicle.IsPositionFrozen = LocationManager.Active.PlaceOnGround;
            vehicle.CanTiresBurst = true;
            ped.Task.ClearAll();
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void SelectCurrent()
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            int r, g, b = 0;

            unsafe
            {
                Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, vehicle, &r, &g, &b);
            }

            Color color = Color.FromArgb(r, g, b);

            foreach (NativeItem rawItem in Items)
            {
                TireSmokeItem item = (TireSmokeItem)rawItem;

                if (item.Color == color)
                {
                    SelectedItem = rawItem;
                    UpdateBadges();
                    return;
                }
            }

            SelectedIndex = 0;
            UpdateBadges(true);
        }
        /// <inheritdoc/>
        public override void Repopulate()
        {
        }

        #endregion
    }
}
