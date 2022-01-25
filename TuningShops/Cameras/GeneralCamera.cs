using GTA;
using GTA.Math;
using System;

namespace TuningShops.Cameras
{
    /// <summary>
    /// The General camera.
    /// </summary>
    internal class GeneralCamera : CameraCore
    {
        #region Constructor

        public GeneralCamera()
        {
            Id = Guid.Empty;
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void Create(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            Destroy();

            (_, Vector3 baseFrontTopRight) = vehicle.Model.Dimensions;

            Vector3 camPosRel = new Vector3(-baseFrontTopRight.X - 2.319f, baseFrontTopRight.Y + 1.058f, baseFrontTopRight.Z - 0.613f);
            Vector3 camPosAbs = vehicle.GetOffsetPosition(camPosRel);

            camera = World.CreateCamera(camPosAbs, Vector3.Zero, 42.5f);
            camera.PointAt(vehicle, new Vector3(0, baseFrontTopRight.Y * 0.3f, 0));

            World.RenderingCamera = camera;
        }

        #endregion
    }
}
