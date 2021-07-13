using GTA;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The armor menu option.
    /// </summary>
    public class LSCArmor : LosSantosCustoms
    {
        #region Constructor

        public LSCArmor() : base(16, "Armor")
        {
            Opening += (sender, e) => Cameras.General(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
