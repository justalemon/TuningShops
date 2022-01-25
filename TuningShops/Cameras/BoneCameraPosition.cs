using GTA;
using GTA.Math;
using Newtonsoft.Json;

namespace TuningShops.Cameras
{
    /// <summary>
    /// A Camera that points to a specific bone.
    /// </summary>
    internal class BoneCameraPosition : SimpleCamera
    {
        #region Properties

        /// <summary>
        /// The bone to look at.
        /// </summary>
        [JsonProperty("bone_name", Required = Required.Always)]
        public string Bone { get; set; }

        #endregion

        #region Constructor

        /// <inheritdoc/>
        public BoneCameraPosition()
        {
        }
        /// <summary>
        /// Creates a new camera position that points at a bone.
        /// </summary>
        /// <param name="cameraOffset">The offset of the camera.</param>
        /// <param name="boneOffset">The offset of the bonne.</param>
        /// <param name="flags">The flags to apply to the camera.</param>
        /// <param name="boneName">The name of the bone.</param>
        public BoneCameraPosition(Vector3 cameraOffset, Vector3 boneOffset, CameraFlags flags, string boneName)
        {
            CameraOffset = cameraOffset;
            BoneOffset = boneOffset;
            Flags = flags;
            Bone = boneName;
        }

        #endregion

        #region Functions

        /// <inheritdoc/>
        public override void Create(Vehicle vehicle)
        {
            Create(vehicle, vehicle.Bones[Bone]);
        }

        #endregion
    }
}
