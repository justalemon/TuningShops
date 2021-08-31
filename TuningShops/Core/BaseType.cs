using GTA;
using LemonUI.Menus;
using System;
using System.ComponentModel;
using TuningShops.Cameras;
using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// Represents the basics for a Mod Slot Type.
    /// </summary>
    public abstract class BaseType : NativeMenu
    {
        #region Fields

        private static readonly BadgeSet set = new BadgeSet()
        {
            HoveredDictionary = "commonmenu",
            HoveredTexture = "shop_garage_icon_b",
            NormalDictionary = "commonmenu",
            NormalTexture = "shop_garage_icon_a"
        };
        private Model lastModel = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The name of this slot.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The last modification value used on this shop.
        /// </summary>
        public int LastValue { get; set; }
        /// <summary>
        /// The value of the modification.
        /// </summary>
        public abstract int ModValue { get; set; }

        #endregion

        #region Constructor

        public BaseType(string name) : base("", name)
        {
            Name = name;
            UseMouse = false;
            Opening += BaseType_Opening;
            SelectedIndexChanged += BaseType_SelectedIndexChanged;
            ItemActivated += BaseType_ItemActivated;
            Closed += BaseType_Closed;
        }

        #endregion

        #region Functions

        /// <summary>
        /// If the specified vehicle can use the menu functions.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>true if the vehicle can use the options of the menu, false otherwise.</returns>
        public abstract bool CanUse(Vehicle vehicle);
        /// <summary>
        /// Selets the currently used modification by the vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        public abstract void SelectCurrent(Vehicle vehicle);
        /// <summary>
        /// Repopulates the number of menu items.
        /// </summary>
        public abstract void Repopulate();
        /// <summary>
        /// Updates the right badge in all of the menu items.
        /// </summary>
        public void UpdateBadges(bool forceNotPurchased = false)
        {
            CoreItem selected = (CoreItem)SelectedItem;

            foreach (NativeItem rawItem in Items)
            {
                CoreItem item = (CoreItem)rawItem;

                item.RightBadgeSet = selected == item && !forceNotPurchased ? set : null;
                item.AltTitle = selected == item && !forceNotPurchased ? "" : $"${item.Value}";

                if (item.RightBadgeSet == null)
                {
                    item.RightBadge = null;
                }
            }
        }

        #endregion

        #region Events

        private void BaseType_Opening(object sender, CancelEventArgs e)
        {
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            Model model = vehicle != null ? vehicle.Model : new Model(0);

            CameraManager.Get(this).Create(vehicle);

            if (vehicle == null)
            {
                Clear();
                lastModel = model;
                return;
            }

            if (model != lastModel)
            {
                Repopulate();
                lastModel = model;
            }

            LastValue = ModValue;

            SelectCurrent(vehicle);
        }
        private void BaseType_SelectedIndexChanged(object sender, SelectedEventArgs e)
        {
            CoreItem item = Items[e.Index] as CoreItem;

            if (item == null)
            {
                return;
            }

            ModValue = item.Index;
        }
        private void BaseType_ItemActivated(object sender, ItemActivatedArgs e)
        {
            CoreItem item = e.Item as CoreItem;

            if (item == null)
            {
                return;
            }

            if (!Money.ChargeIfPossible(item.Value))
            {
                return;
            }

            LastValue = item.Index;

            UpdateBadges();
        }
        private void BaseType_Closed(object sender, EventArgs e)
        {
            ModValue = LastValue;
        }

        #endregion
    }
}
