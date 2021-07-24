using GTA;
using GTA.Math;
using GTA.Native;
using Newtonsoft.Json;
using System;
using TuningShops.Memory;

namespace TuningShops.Cameras
{
    /// <summary>
    /// A camera that points to a specific eVehicleModType.
    /// </summary>
    public class ModCameraPosition : SimpleCamera
    {
        #region Properties

        /// <summary>
        /// The modification to look at.
        /// </summary>
        [JsonProperty("mod_slot")]
        public EVehicleModType ModSlot { get; set; }

        #endregion

        #region Constructor

        /// <inheritdoc/>
        public ModCameraPosition()
        {
        }
        /// <summary>
        /// Creates a new camera position that points at specific modification.
        /// </summary>
        /// <param name="cameraOffset">The offset of the camera.</param>
        /// <param name="boneOffset">The offset of the bonne.</param>
        /// <param name="flags">The flags to apply to the camera.</param>
        /// <param name="modSlot">The slot to look at.</param>
        public ModCameraPosition(Vector3 cameraOffset, Vector3 boneOffset, CameraFlags flags, EVehicleModType modSlot)
        {
            CameraOffset = cameraOffset;
            BoneOffset = boneOffset;
            Flags = flags;
            ModSlot = modSlot;
        }

        #endregion

        #region Properties

        /// <inheritdoc/>
        public unsafe override void Create(Vehicle vehicle)
        {
            int kitIndex = Function.Call<int>(Hash.GET_VEHICLE_MOD_KIT, vehicle);

            CVehicleModelInfoVarGlobal* varGlobal = *TuningShops.gVehicleModelInfoVarGlobal;

            if (kitIndex < 0 || kitIndex >= varGlobal->Kits.Count)
            {
                throw new ArgumentOutOfRangeException("The Kit index is over the limit.");
            }

            CVehicleKit* kit = &varGlobal->Kits.Items[kitIndex];

            for (int i = 0; i < kit->visibleMods.Count; i++)
            {
                CVehicleModVisible* mod = &kit->visibleMods.Items[i];

                if (mod->type == ModSlot)
                {
                    Create(vehicle, vehicle.Bones[(int)mod->bone]);
                    return;
                }
            }

            throw new SystemException("The Mod Slot was not found on the Vehicle Mod Kit.");
        }

        #endregion
    }
}
