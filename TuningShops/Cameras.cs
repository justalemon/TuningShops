using GTA;
using GTA.Math;
using GTA.Native;

namespace TuningShops
{
    /// <summary>
    /// Simple tool to set the camera on specific vehicle positions.
    /// </summary>
    public static class Cameras
    {
        private static Camera camera = null;

        /// <summary>
        /// Clears the Player's camera by restoring the default rendering camera.
        /// </summary>
        public static void ClearCamera()
        {
            World.RenderingCamera = null;
            if (camera != null)
            {
                camera.Delete();
                camera = null;
            }
        }
        /// <summary>
        /// Sets a general camera near the player's vehicle.
        /// </summary>
        public static void General(Vehicle vehicle)
        {
            ClearCamera();

            (Vector3 rearBottomLeft, Vector3 frontTopRight) = vehicle.Model.Dimensions;
            Vector3 relPos = new Vector3(-frontTopRight.X, frontTopRight.Y, frontTopRight.Z);
            GTA.UI.Screen.ShowSubtitle($"{rearBottomLeft} - {frontTopRight}");
            Vector3 camPos = vehicle.GetOffsetPosition(new Vector3(relPos.X - 8.262f, relPos.Y - 3.401f, relPos.Z + 0.048f));
            camera = World.CreateCamera(camPos, Vector3.Zero, 25);
            camera.PointAt(vehicle);
            World.RenderingCamera = camera;
        }
    }
}
