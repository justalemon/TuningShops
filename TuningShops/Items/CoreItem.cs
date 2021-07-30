using LemonUI.Menus;

namespace TuningShops.Items
{
    /// <summary>
    /// The basic item for all of the modifications.
    /// </summary>
    public class CoreItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// The value of this modification.
        /// </summary>
        public virtual int Value { get; }
        /// <summary>
        /// The index of the modification.
        /// </summary>
        public virtual int Index { get; }

        #endregion

        #region Properties

        public CoreItem(int index, string name, string description, int value) : base(name, description, $"${value}")
        {
            Index = index;
            Value = value;
        }

        #endregion
    }
}
