using LemonUI.Menus;

namespace TuningShops.Items
{
    /// <summary>
    /// The basic item for all of the modifications.
    /// </summary>
    public class CoreItem : NativeItem
    {
        #region Fields

        private int value = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The value of this modification.
        /// </summary>
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                if (RightBadgeSet == null)
                {
                    AltTitle = $"${value}";
                }
            }
        }
        /// <summary>
        /// The index of the modification.
        /// </summary>
        public int Index { get; }

        #endregion

        #region Properties

        public CoreItem(int index, string name, string description, int value) : base(name, description)
        {
            Index = index;
            Value = value;
        }

        #endregion
    }
}
