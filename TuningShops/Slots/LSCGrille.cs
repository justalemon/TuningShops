using GTA;
using System;
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
            Opening += (sender, e) => CameraManager.Get(Guid.Parse("6c939927-7448-4639-80b0-ea1c04571753")).Create(Game.Player.Character.CurrentVehicle);
        }

        #endregion
    }
}
