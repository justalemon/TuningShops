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
        /// <summary>
        /// Points at the front bumper of the vehicle.
        /// </summary>
        public static void FrontBumper(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "bumper_f", new Vector3(0, 5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the rear bumper of the vehicle.
        /// </summary>
        public static void RearBumper(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "bumper_r", new Vector3(0, -5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the engine of the vehicle.
        /// </summary>
        public static void Engine(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "bonnet", new Vector3(0, 5, 1), Vector3.Zero);
        /// <summary>
        /// Points at the exhaust pipes of the vehicle.
        /// </summary>
        public static void Exhaust(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "exhaust", new Vector3(0, -5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the headlights pipes of the vehicle.
        /// </summary>
        public static void Headlights(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "headlight_l", new Vector3(0, 5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the hood of the vehicle.
        /// </summary>
        public static void Hood(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "bonnet", new Vector3(0, 2, 5), new Vector3(0, 2, 0));

        private static void PointAtBoneWithOffset(Vehicle vehicle, string boneName, Vector3 camOffset, Vector3 centerOffset)
        {
            ClearCamera();

            EntityBone bone = vehicle.Bones[boneName];

            if (bone == null)
            {
                General(vehicle);
                return;
            }

            Vector3 source = bone.RelativePosition;
            Vector3 center = new Vector3(0, source.Y, source.Z) + centerOffset;

            camera = World.CreateCamera(vehicle.GetOffsetPosition(new Vector3(center.X + camOffset.X, center.Y + camOffset.Y, center.Z + camOffset.Z)), Vector3.Zero, 30);
            camera.PointAt(vehicle.GetOffsetPosition(center));
            World.RenderingCamera = camera;
        }
    }
}
