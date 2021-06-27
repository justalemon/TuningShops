namespace TuningShops.Menus
{
    /// <summary>
    /// Menu used to toggle items on or off.
    /// </summary>
    public class MenuToggle : MenuBase
    {
        #region Constructors

        public MenuToggle(int slot) : base(slot)
        {
            Add(new ItemToggle(slot, false));
            Add(new ItemToggle(slot, true));
        }

        #endregion
    }
}
