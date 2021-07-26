using GTA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TuningShops.Cameras
{
    /// <summary>
    /// Represents the different Overrides done by a specific vehicle.
    /// </summary>
    public class CameraOverride
    {
        /// <summary>
        /// The Model that uses this set of overrides.
        /// </summary>
        [JsonProperty("model", Required = Required.Always)]
        public Model Model { get; set; }
        /// <summary>
        /// The overrides to apply.
        /// </summary>
        [JsonProperty("overrides", Required = Required.Always)]
        public Dictionary<string, Guid> Overrides { get; set; }
    }
}
