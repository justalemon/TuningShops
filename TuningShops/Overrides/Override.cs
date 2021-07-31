using GTA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TuningShops.Overrides
{
    /// <summary>
    /// Represents the different Overrides done by a specific vehicle.
    /// </summary>
    public class Override
    {
        /// <summary>
        /// The Model that uses this set of overrides.
        /// </summary>
        [JsonProperty("model", Required = Required.Always)]
        public Model Model { get; set; }
        /// <summary>
        /// The camera overrides.
        /// </summary>
        [JsonProperty("cameras", Required = Required.Always)]
        public Dictionary<string, Guid> Cameras { get; set; }
    }
}
