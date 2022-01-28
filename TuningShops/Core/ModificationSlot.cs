using GTA;
using LemonUI.Menus;
using System;
using System.ComponentModel;
using TuningShops.Cameras;
using TuningShops.Items;

namespace TuningShops.Core
{
    /// <summary>
    /// The core of the different Modification Slots.
    /// </summary>
    public abstract class ModificationSlot : NativeMenu
    {
        #region Fields

        private static readonly BadgeSet set = new BadgeSet()
        {
            HoveredDictionary = "commonmenu",
            HoveredTexture = "shop_garage_icon_b",
            NormalDictionary = "commonmenu",
            NormalTexture = "shop_garage_icon_a"
        };

        #endregion

        #region Properties

        /// <summary>
        /// The name of this slot.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// If the items should always be shown as not purchased
        /// </summary>
        public bool ShowsAsNonPurchased { get; set; } = false;
        /// <summary>
        /// If this Modification Slot can be used by the current player's vehicle.
        /// </summary>
        public abstract bool CanBeUsed { get; }

        #endregion

        #region Constructor

        public ModificationSlot(string name) : base("", name)
        {
            Name = name;
            CloseOnInvalidClick = false;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Selets the currently used modification by the vehicle.
        /// </summary>
        public abstract void SelectCurrent();
        /// <summary>
        /// Repopulates the number of menu items.
        /// </summary>
        public abstract void Repopulate();
        /// <summary>
        /// Updates the right badge in all of the menu items.
        /// </summary>
        public void UpdateBadges(bool forceNotPurchased = false)
        {
            StoreItem selected = (StoreItem)SelectedItem;

            foreach (NativeItem rawItem in Items)
            {
                StoreItem item = (StoreItem)rawItem;

                item.RightBadgeSet = selected == item && !forceNotPurchased ? set : null;
                item.AltTitle = selected == item && !forceNotPurchased ? "" : $"${item.Price}";

                if (item.RightBadgeSet == null)
                {
                    item.RightBadge = null;
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Represents the basics for a Mod Slot Type.
    /// </summary>
    public abstract class ModificationSlot<T> : ModificationSlot
    {
        #region Fields

        private Model lastModel = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The modification that was present before the menu was opened.
        /// </summary>
        public virtual T LastModification { get; set; }
        /// <summary>
        /// The current modification selected.
        /// </summary>
        public virtual T CurrentModification { get; set; }

        #endregion

        #region Constructor

        public ModificationSlot(string name) : base(name)
        {
            Opening += BaseType_Opening;
            SelectedIndexChanged += ModificationSlot_SelectedIndexChanged;
            ItemActivated += BaseType_ItemActivated;
            Closed += BaseType_Closed;
        }

        #endregion

        #region Functions


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

            LastModification = CurrentModification;

            SelectCurrent();
        }
        private void ModificationSlot_SelectedIndexChanged(object sender, SelectedEventArgs e)
        {
            if (SelectedItem is StoreItem item)
            {
                item.Apply();
            }
        }
        private void BaseType_ItemActivated(object sender, ItemActivatedArgs e)
        {
            StoreItem item = e.Item as StoreItem;

            if (item == null || item.RightBadgeSet != null || !Money.ChargeIfPossible(item.Price))
            {
                return;
            }

            LastModification = CurrentModification;
            UpdateBadges(ShowsAsNonPurchased);
        }
        private void BaseType_Closed(object sender, EventArgs e)
        {
            CurrentModification = LastModification;
        }

        #endregion
    }
}
