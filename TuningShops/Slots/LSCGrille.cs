using GTA;
using TuningShops.Cameras;
using TuningShops.Core;

namespace TuningShops.Slots
{
    /// <summary>
    /// The grille menu option.
    /// </summary>
    public class LSCGrille : LosSantosCustoms
    {
        #region Constructor

        public LSCGrille() : base(6, "Grille")
        {
            Opening += (sender, e) => CameraSet.Grille.Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
