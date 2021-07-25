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
            Vector3 camPos = vehicle.GetOffsetPosition(new Vector3(relPos.X - 8.262f, relPos.Y - 3.401f, relPos.Z + 0.048f));
            camera = World.CreateCamera(camPos, Vector3.Zero, 25);
            camera.PointAt(vehicle);
            World.RenderingCamera = camera;
        }
    }
}
