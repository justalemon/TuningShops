using System;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Different tweaks for the Vehicle Camera.
    /// </summary>
    [Flags]
    internal enum CameraFlags
    {
        None = 0,
        CenterBoneX = 1,
        HidePlayer = 2,
        WideFov = 4,
        FromDriver = 8,
        CenterCameraX = 16,
        CameraRelativeSize = 32,
    }
}
