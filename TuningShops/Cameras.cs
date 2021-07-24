using GTA;
using GTA.Math;
using GTA.Native;
using System;
using TuningShops.Camera;
using TuningShops.Memory;

namespace TuningShops
{
    /// <summary>
    /// Simple tool to set the camera on specific vehicle positions.
    /// </summary>
    public static class Cameras
    {
        #region Fields

        private static GTA.Camera camera = null;

        #endregion

        #region Tools

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
            Game.Player.Character.IsVisible = true;
            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            {
                vehicle.IsInteriorLightOn = false;
            }
        }

        #endregion

        #region Cameras

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
        public static void FrontBumper(Vehicle vehicle) => PointAtBone(vehicle, "bumper_f", new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void RearBumper(Vehicle vehicle) => PointAtBone(vehicle, EVehicleModType.VMT_BUMPER_R, new Vector3(0, -5, 0), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Engine(Vehicle vehicle) => PointAtBone(vehicle, "bonnet", new Vector3(0, 5, 1), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Exhaust(Vehicle vehicle) => PointAtBone(vehicle, EVehicleModType.VMT_EXHAUST, new Vector3(0, -5, 0), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Headlights(Vehicle vehicle) => PointAtBone(vehicle, "headlight_l", new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Hood(Vehicle vehicle) => PointAtBone(vehicle, EVehicleModType.VMT_BONNET, new Vector3(0, 3, 2), new Vector3(0, 0.5f, 0), CameraFlags.CenterBoneX);
        public static void FrontLeftWheel(Vehicle vehicle) => PointAtBone(vehicle, "wheel_lf", new Vector3(-3, 0, 0), Vector3.Zero, CameraFlags.None);
        public static void RearLeftWheel(Vehicle vehicle) => PointAtBone(vehicle, "wheel_lr", new Vector3(-3, 0, 0), Vector3.Zero, CameraFlags.None);
        public static void PlateLight(Vehicle vehicle) => PointAtBone(vehicle, "platelight", new Vector3(0, -1, 0), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Spoiler(Vehicle vehicle) => PointAtBone(vehicle, EVehicleModType.VMT_SPOILER, new Vector3(0, -7, 1), Vector3.Zero, CameraFlags.CenterBoneX);
        public static void Fender(Vehicle vehicle) => PointAtBone(vehicle, EVehicleModType.VMT_WING_L, new Vector3(-7, 0, 0), Vector3.Zero, CameraFlags.None);
        public static void SteeringWheel(Vehicle vehicle) => PointAtBone(vehicle, "steeringwheel", Vector3.Zero, Vector3.Zero, CameraFlags.HidePlayer | CameraFlags.WideFov | CameraFlags.FromDriver);
        public static void Dashboard(Vehicle vehicle) => PointAtBone(vehicle, "steeringwheel", new Vector3(0, -0.6f, 0.25f), new Vector3(-0.25f, 0, 0), CameraFlags.CenterBoneX | CameraFlags.HidePlayer | CameraFlags.WideFov);
        public static void FrontLeftDoor(Vehicle vehicle) => PointAtBone(vehicle, "door_dside_f", new Vector3(0, 0, 0), new Vector3(-1f, 0, 0), CameraFlags.HidePlayer | CameraFlags.WideFov | CameraFlags.FromDriver);
        public static void Ornament(Vehicle vehicle) => PointAtBone(vehicle, "bobble_head", Vector3.Zero, Vector3.Zero, CameraFlags.HidePlayer | CameraFlags.FromDriver);
        public static void EngineBlock(Vehicle vehicle) => PointAtBone(vehicle, "bonnet", new Vector3(-3, 0, 2), new Vector3(0, -1, 0), CameraFlags.None);

        #endregion

        #region Bone Camera Pointers

        public static unsafe void PointAtBone(Vehicle vehicle, EVehicleModType slot, Vector3 camOffset, Vector3 centerOffset, CameraFlags flags)
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
                    PointAtBone(vehicle, vehicle.Bones[(int)mod->bone], camOffset, centerOffset, flags);
                    return;
                }
            }
        }
        private static void PointAtBone(Vehicle vehicle, string boneName, Vector3 camOffset, Vector3 centerOffset, CameraFlags flags)
        {
            PointAtBone(vehicle, vehicle.Bones[boneName], camOffset, centerOffset, flags);
        }
        private static void PointAtBone(Vehicle vehicle, EntityBone bone, Vector3 camOffset, Vector3 centerOffset, CameraFlags flags)
        {
            ClearCamera();

            if (bone == null)
            {
                General(vehicle);
                return;
            }

            if (flags.HasFlag(CameraFlags.HidePlayer))
            {
                Game.Player.Character.IsVisible = false;
            }
            vehicle.IsInteriorLightOn = true;

            Vector3 bonePos = bone.RelativePosition;
            Vector3 camPos = flags.HasFlag(CameraFlags.FromDriver) ? vehicle.GetPositionOffset(vehicle.GetPedOnSeat(VehicleSeat.Driver).Bones[Bone.SkelHead].Position) : bonePos;

            Vector3 target = new Vector3(flags.HasFlag(CameraFlags.CenterBoneX) ? 0 : bonePos.X, bonePos.Y, bonePos.Z) + centerOffset;

            camera = World.CreateCamera(vehicle.GetOffsetPosition(new Vector3(camPos.X + camOffset.X, camPos.Y + camOffset.Y, camPos.Z + camOffset.Z)), Vector3.Zero, flags.HasFlag(CameraFlags.WideFov) ? 50 : 30);
            camera.PointAt(vehicle.GetOffsetPosition(target));
            World.RenderingCamera = camera;
        }

        #endregion
    }
}
