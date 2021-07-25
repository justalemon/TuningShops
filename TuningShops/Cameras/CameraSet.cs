using GTA.Math;
using TuningShops.Memory;

namespace TuningShops.Cameras
{
    /// <summary>
    /// The set of base cameras from the core mod.
    /// </summary>
    public static class CameraSet
    {
        public static GeneralCamera General { get; } = new GeneralCamera();
        public static BoneCameraPosition FrontBumper { get; } = new BoneCameraPosition(new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX | CameraFlags.CenterCameraX, "bumper_f");
        public static ModCameraPosition RearBumper { get; } = new ModCameraPosition(new Vector3(0, -5, 0), Vector3.Zero, CameraFlags.CenterBoneX | CameraFlags.CenterCameraX, EVehicleModType.VMT_BUMPER_R);
        public static BoneCameraPosition Engine { get; } = new BoneCameraPosition(new Vector3(0, 5, 1), Vector3.Zero, CameraFlags.CenterBoneX | CameraFlags.CenterCameraX, "bonnet");
        public static ModCameraPosition Exhaust { get; } = new ModCameraPosition(new Vector3(0, -5, 0), Vector3.Zero, CameraFlags.CenterBoneX | CameraFlags.CenterCameraX, EVehicleModType.VMT_EXHAUST);
        public static BoneCameraPosition Headlights { get; } = new BoneCameraPosition(new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX, "headlight_l");
        public static ModCameraPosition Hood { get; } = new ModCameraPosition(new Vector3(0, 3, 2), new Vector3(0, 0.5f, 0), CameraFlags.CenterBoneX, EVehicleModType.VMT_BONNET);
        public static BoneCameraPosition FrontLeftWheel { get; } = new BoneCameraPosition(new Vector3(-3, 0, 0), Vector3.Zero, CameraFlags.None, "wheel_lf");
        public static BoneCameraPosition RearLeftWheel { get; } = new BoneCameraPosition(new Vector3(-3, 0, 0), Vector3.Zero, CameraFlags.None, "wheel_lr");
        public static BoneCameraPosition PlateLight { get; } = new BoneCameraPosition(new Vector3(0, -1, 0), Vector3.Zero, CameraFlags.CenterBoneX, "platelight");
        public static ModCameraPosition Spoiler { get; } = new ModCameraPosition(new Vector3(0, -7, 1), Vector3.Zero, CameraFlags.CenterBoneX, EVehicleModType.VMT_SPOILER);
        public static ModCameraPosition Fender { get; } = new ModCameraPosition(new Vector3(-7, 0, 0), Vector3.Zero, CameraFlags.None, EVehicleModType.VMT_WING_L);
        public static BoneCameraPosition SteeringWheel { get; } = new BoneCameraPosition(Vector3.Zero, Vector3.Zero, CameraFlags.HidePlayer | CameraFlags.WideFov | CameraFlags.FromDriver, "steeringwheel");
        public static BoneCameraPosition Dashboard { get; } = new BoneCameraPosition(new Vector3(0, -0.6f, 0.25f), new Vector3(-0.25f, 0, 0), CameraFlags.CenterBoneX | CameraFlags.HidePlayer | CameraFlags.WideFov, "steeringwheel");
        public static BoneCameraPosition FrontLeftDoor { get; } = new BoneCameraPosition(Vector3.Zero, new Vector3(-1f, 0, 0), CameraFlags.HidePlayer | CameraFlags.WideFov | CameraFlags.FromDriver, "door_dside_f");
        public static BoneCameraPosition Ornament { get; } = new BoneCameraPosition(Vector3.Zero, Vector3.Zero, CameraFlags.HidePlayer | CameraFlags.FromDriver, "bobble_head");
        public static BoneCameraPosition EngineBlock { get; } = new BoneCameraPosition(new Vector3(-3, 0, 2), new Vector3(0, -1, 0), CameraFlags.None, "bonnet");
        public static ModCameraPosition Grille { get; } = new ModCameraPosition(new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX, EVehicleModType.VMT_GRILL);
        public static ModCameraPosition Aerials { get; } = new ModCameraPosition(new Vector3(0, 5, 0), Vector3.Zero, CameraFlags.CenterBoneX, EVehicleModType.VMT_CHASSIS3);
    }
}
