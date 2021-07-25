using GTA;
using GTA.Math;
using Newtonsoft.Json;
using TuningShops.Converters;

namespace TuningShops.Locations
{
    /// <summary>
    /// The Spawn information of a Ped.
    /// </summary>
    public class ShopPed
    {
        /// <summary>
        /// The position of the ped over the counter.
        /// </summary>
        [JsonProperty("pos", Required = Required.Always)]
        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Position { get; set; }
        /// <summary>
        /// The Heading of the ped.
        /// </summary>
        [JsonProperty("heading", Required = Required.Always)]
        public float Heading { get; set; }
        /// <summary>
        /// The model of the ped.
        /// </summary>
        [JsonProperty("model", Required = Required.Always)]
        public Model Model { get; set; }
    }
}
