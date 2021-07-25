using GTA;
using GTA.Math;
using System;

namespace TuningShops.Cameras
{
    /// <summary>
    /// The General camera.
    /// </summary>
    public class GeneralCamera : CameraCore
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

            (_, Vector3 frontTopRight) = vehicle.Model.Dimensions;
            Vector3 relPos = new Vector3(-frontTopRight.X, frontTopRight.Y, frontTopRight.Z);

            Vector3 camPos = vehicle.GetOffsetPosition(new Vector3(relPos.X - 2.319f, relPos.Y + 1.058f, relPos.Z - 0.613f));

            camera = World.CreateCamera(camPos, Vector3.Zero, 42.5f);
            camera.PointAt(vehicle, new Vector3(0, frontTopRight.Y * 0.3f, 0));
            World.RenderingCamera = camera;
        }

        #endregion
    }
}
