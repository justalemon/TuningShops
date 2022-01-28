using LemonUI.Menus;

namespace TuningShops.Core
{
    /// <summary>
    /// The item used for sales.
    /// </summary>
    public abstract class StoreItem : NativeItem
    {
        #region Fields

        private int price = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The price of this modification.
        /// </summary>
        public int Price
        {
            get => price;
            set
            {
                price = value;
                if (RightBadgeSet == null)
                {
                    AltTitle = $"${value}";
                }
            }
        }

        #endregion

        #region Properties

        public StoreItem(string name, int price) : this(name, "", price)
        {
        }
        public StoreItem(string name, string description, int price) : base(name, description)
        {
            Price = price;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the modification.
        /// </summary>
        public abstract void Apply();

        #endregion
    }
}
