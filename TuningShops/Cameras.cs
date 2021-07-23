using GTA;
using GTA.Math;
using GTA.Native;
using TuningShops.Memory;

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

            (_, Vector3 frontTopRight) = vehicle.Model.Dimensions;
            Vector3 relPos = new Vector3(-frontTopRight.X, frontTopRight.Y, frontTopRight.Z);
            Vector3 camPos = vehicle.GetOffsetPosition(new Vector3(relPos.X - 8.262f, relPos.Y - 3.401f, relPos.Z + 0.048f));
            camera = World.CreateCamera(camPos, Vector3.Zero, 25);
            camera.PointAt(vehicle);
            World.RenderingCamera = camera;
        }
        /// <summary>
        /// Points at the front bumper of the vehicle.
        /// </summary>
        public static void FrontBumper(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, EVehicleModType.VMT_BUMPER_F, new Vector3(0, 5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the rear bumper of the vehicle.
        /// </summary>
        public static void RearBumper(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, EVehicleModType.VMT_BUMPER_R, new Vector3(0, -5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the engine of the vehicle.
        /// </summary>
        public static void Engine(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "bonnet", new Vector3(0, 5, 1), Vector3.Zero);
        /// <summary>
        /// Points at the exhaust pipes of the vehicle.
        /// </summary>
        public static void Exhaust(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, EVehicleModType.VMT_EXHAUST, new Vector3(0, -5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the headlights pipes of the vehicle.
        /// </summary>
        public static void Headlights(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "headlight_l", new Vector3(0, 5, 0), Vector3.Zero);
        /// <summary>
        /// Points at the hood of the vehicle.
        /// </summary>
        public static void Hood(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, EVehicleModType.VMT_BONNET, new Vector3(0, 3, 2), new Vector3(0, 0.5f, 0));
        /// <summary>
        /// Points at the front left wheel of the vehicle.
        /// </summary>
        public static void FrontLeftWheel(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "wheel_lf", new Vector3(-3, 0, 0), Vector3.Zero);
        /// <summary>
        /// Points at the rear left wheel of the vehicle.
        /// </summary>
        public static void RearLeftWheel(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "wheel_lr", new Vector3(-3, 0, 0), Vector3.Zero);
        /// <summary>
        /// Points at the plate light of the vehicle.
        /// </summary>
        public static void PlateLight(Vehicle vehicle) => PointAtBoneWithOffset(vehicle, "platelight", new Vector3(0, -1, 0), Vector3.Zero);

        public static unsafe void PointAtBoneWithOffset(Vehicle vehicle, EVehicleModType slot, Vector3 camOffset, Vector3 centerOffset)
        {
            int kitIndex = Function.Call<int>(Hash.GET_VEHICLE_MOD_KIT, vehicle);

            if (kitIndex == 0xFFFF)
            {
                General(vehicle);
                return;
            }

            CVehicleModelInfoVarGlobal* varGlobal = *TuningShops.gVehicleModelInfoVarGlobal;

            if (kitIndex < 0 || kitIndex >= varGlobal -> Kits.Count)
            {
                General(vehicle);
                return;
            }

            CVehicleKit* kit = &varGlobal -> Kits.Items[kitIndex];

            for (int i = 0; i < kit->visibleMods.Count; i++)
            {
                CVehicleModVisible* mod = &kit->visibleMods.Items[i];

                if (mod->type == slot)
                {
                    PointAtBoneWithOffset(vehicle, vehicle.Bones[(int)mod->bone], camOffset, centerOffset);
                    return;
                }
            }
        }
        private static void PointAtBoneWithOffset(Vehicle vehicle, string boneName, Vector3 camOffset, Vector3 centerOffset)
        {
            PointAtBoneWithOffset(vehicle, vehicle.Bones[boneName], camOffset, centerOffset);
        }
        private static void PointAtBoneWithOffset(Vehicle vehicle, EntityBone bone, Vector3 camOffset, Vector3 centerOffset)
        {
            ClearCamera();

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
