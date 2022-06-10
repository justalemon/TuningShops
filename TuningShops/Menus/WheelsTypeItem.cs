using TuningShops.Core;

namespace TuningShops.Menus
{
    /// <summary>
    /// Item used to set the type of wheels.
    /// </summary>
    internal class WheelsTypeItem : StoreItem
    {
        #region Properties

        /// <summary>
        /// The type of wheels.
        /// </summary>
        public int Type { get; }

        #endregion

        #region Constructors

        public WheelsTypeItem(int type, string name) : base(name, 0)
        {
            Type = type;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Applies the Wheel Type.
        /// </summary>
        public override void Apply()
        {
        }

        #endregion
    }
}
