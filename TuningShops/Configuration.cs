using Newtonsoft.Json;

namespace TuningShops
{
    /// <summary>
    /// The configuration of TuningShops.
    /// </summary>
    public class Configuration : ConfigurationCore
    {
        /// <summary>
        /// If the round markers should be shown in the entrance of the Tuning Shops.
        /// </summary>
        [JsonProperty("marker_show")]
        public bool ShowMarkers { get; set; } = true;
        /// <summary>
        /// The distance from the markers where they start being drawn.
        /// </summary>
        [JsonProperty("marker_distance")]
        public float MarkerDistance { get; set; } = 100f;
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
        /// <summary>
        /// The Red component for the Blip Color. This will take effect once the mod is restarted.
        /// </summary>
        [JsonProperty("blip_r")]
        public byte BlipColorR { get; set; } = 128;
        /// <summary>
        /// The Green component for the Blip Color. This will take effect once the mod is restarted.
        /// </summary>
        [JsonProperty("blip_g")]
        public byte BlipColorG { get; set; }
        /// <summary>
        /// The Blue component for the Blip Color. This will take effect once the mod is restarted.
        /// </summary>
        [JsonProperty("blip_b")]
        public byte BlipColorB { get; set; } = 128;
        /// <summary>
        /// The Alpha or Transparency component for the Blip Color. This will take effect once the mod is restarted.
        /// </summary>
        [JsonProperty("blip_a")]
        public byte BlipColorA { get; set; } = 200;
        /// <summary>
        /// Whether to merge the blips into a single category without individual names. This will take effect once the mod is restarted.
        /// </summary>
        [JsonProperty("merge_blips")]
        public bool MergeBlips { get; set; }
    }
}
