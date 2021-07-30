using LemonUI.Menus;

namespace TuningShops.Core
{
    /// <summary>
    /// The basic item for all of the modifications.
    /// </summary>
    public class ModItem : NativeItem
    {
        #region Properties

        /// <summary>
        /// The value of this modification.
        /// </summary>
        public virtual int Value { get; }

        #endregion

        #region Properties

        public ModItem(string name, string description, int value) : base(name, description, $"${value}")
        {
            Value = value;
        }

        #endregion
    }
}
