using Newtonsoft.Json;

namespace TuningShops
{
    /// <summary>
    /// The configuration of TuningShops.
    /// </summary>
    public class Configuration : ConfigurationCore
    {
        /// <summary>
        /// The Red component for the Marker Color.
        /// </summary>
        [JsonProperty("marker_r")]
        public byte MarkerColorR { get; set; } = 128;
        /// <summary>
        /// The Green component for the Marker Color.
        /// </summary>
        [JsonProperty("marker_g")]
        public byte MarkerColorG { get; set; }
        /// <summary>
        /// The Blue component for the Marker Color.
        /// </summary>
        [JsonProperty("marker_b")]
        public byte MarkerColorB { get; set; } = 128;
        /// <summary>
        /// The Alpha or Transparency component for the Marker Color.
        /// </summary>
        [JsonProperty("marker_a")]
        public byte MarkerColorA { get; set; } = 200;
    }
}
