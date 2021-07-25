using GTA;
using Newtonsoft.Json;
using System;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Represents the basics of the different vehicle cameras.
    /// </summary>
    public abstract class CameraCore
    {
        #region Fields

        protected static Camera camera = null;

        #endregion

        #region Properties

        /// <summary>
        /// The Unique Identifier of this Camera Position.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public Guid Id { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Creates the custom camera from the specified vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to use as a base.</param>
        public abstract void Create(Vehicle vehicle);
        /// <summary>
        /// Destroys the existing camera and restores the gameplay camera, if any.
        /// </summary>
        public static void Destroy()
        {
            World.RenderingCamera = null;

            if (camera != null)
            {
                camera.Delete();
                camera = null;
            }

            Game.Player.Character.IsVisible = true;

            Vehicle vehicle = Game.Player.Character.CurrentVehicle;
            if (vehicle != null)
            {
                vehicle.IsInteriorLightOn = false;
            }
        }

        #endregion
    }
}
