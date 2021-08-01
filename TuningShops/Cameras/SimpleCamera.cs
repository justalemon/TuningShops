using GTA;
using GTA.Math;
using Newtonsoft.Json;
using System;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Represents the position of a Camera relative to a vehicle.
    /// </summary>
    public abstract class SimpleCamera : CameraCore
    {
        #region Properties

        /// <summary>
        /// The Offset of the camera.
        /// </summary>
        [JsonProperty("offset_camera", Required = Required.Always)]
        public Vector3 CameraOffset { get; set; }
        /// <summary>
        /// The Offset of the target Bone.
        /// </summary>
        [JsonProperty("offset_bone", Required = Required.Always)]
        public Vector3 BoneOffset { get; set; }
        /// <summary>
        /// The Flags to use for this camera.
        /// </summary>
        [JsonProperty("flags", Required = Required.Always)]
        public CameraFlags Flags { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new empty Camera Position.
        /// </summary>
        public SimpleCamera()
        {
        }

        #endregion

        #region Functions

        /// <summary>
        /// Creates the custom camera from the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to use as a base.</param>
        /// <param name="bone">The bone to look at.</param>
        protected void Create(Vehicle vehicle, EntityBone bone)
        {
            if (vehicle == null)
            {
                throw new NullReferenceException(nameof(vehicle));
            }
            if (bone == null)
            {
                throw new NullReferenceException(nameof(bone));
            }

            Destroy();

            if (Flags.HasFlag(CameraFlags.HidePlayer))
            {
                Game.Player.Character.IsVisible = false;
            }
            vehicle.IsInteriorLightOn = true;

            (_, Vector3 frontTopRight) = vehicle.Model.Dimensions;

            Vector3 bonePos = bone.RelativePosition;
            Vector3 baseCamPos = Flags.HasFlag(CameraFlags.FromDriver) ? vehicle.GetPositionOffset(vehicle.GetPedOnSeat(VehicleSeat.Driver).Bones[Bone.SkelHead].Position) : bonePos;
            Vector3 camOffset = Flags.HasFlag(CameraFlags.CameraRelativeSize) ? new Vector3(CameraOffset.X * frontTopRight.X, CameraOffset.Y * frontTopRight.Y, CameraOffset.Z * frontTopRight.Z) : CameraOffset;

            Vector3 target = new Vector3(Flags.HasFlag(CameraFlags.CenterBoneX) ? 0 : bonePos.X, bonePos.Y, bonePos.Z) + BoneOffset;

            Vector3 relativeCamPos = new Vector3(Flags.HasFlag(CameraFlags.CenterCameraX) ? 0 : (baseCamPos.X + camOffset.X), baseCamPos.Y + camOffset.Y, baseCamPos.Z + camOffset.Z);

            camera = World.CreateCamera(vehicle.GetOffsetPosition(relativeCamPos), Vector3.Zero, Flags.HasFlag(CameraFlags.WideFov) ? 50 : 30);
            camera.PointAt(vehicle.GetOffsetPosition(target));
            World.RenderingCamera = camera;
        }

        #endregion
    }
}
