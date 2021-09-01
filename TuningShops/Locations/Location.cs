using GTA;
using GTA.Math;
using GTA.Native;
using Newtonsoft.Json;
using System.Collections.Generic;
using TuningShops.Converters;

namespace TuningShops.Locations
{
    /// <summary>
    /// Represents the location of a tuning shop.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The name of this Shop.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        /// <summary>
        /// The dictionary where the banner texture is.
        /// </summary>
        [JsonProperty("banner_txd", Required = Required.Always)]
        public string BannerTXD { get; set; }
        /// <summary>
        /// The texture to use as a banner.
        /// </summary>
        [JsonProperty("banner_texture", Required = Required.Always)]
        public string BannerTexture { get; set; }
        /// <summary>
        /// The marker trigger used to open the menu.
        /// </summary>
        [JsonProperty("trigger_pos", Required = Required.Always)]
        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 Trigger { get; set; }
        /// <summary>
        /// The size of the trigger that opens the menu.
        /// </summary>
        [JsonProperty("trigger_size", Required = Required.Always)]
        public float TriggerSize { get; set; }
        /// <summary>
        /// The position of the vehicle when arriving at the tuning shop.
        /// </summary>
        [JsonProperty("veh_pos", Required = Required.Always)]
        [JsonConverter(typeof(Vector3Converter))]
        public Vector3 VehiclePos { get; set; }
        /// <summary>
        /// The heading of the vehicle when arriving at the tuning shop.
        /// </summary>
        [JsonProperty("veh_heading", Required = Required.Always)]
        public float VehicleHeading { get; set; }
        /// <summary>
        /// If the vehicle should be placed on the ground when opening the menu.
        /// </summary>
        [JsonProperty("place_on_ground", Required = Required.Always)]
        public bool PlaceOnGround { get; set; }
        /// <summary>
        /// The location where an interior should be checked.
        /// </summary>
        [JsonProperty("interior", Required = Required.AllowNull)]
        [JsonConverter(typeof(Vector3Converter))]
        public Vector3? Interior { get; set; }
        /// <summary>
        /// The information of the shop ped.
        /// </summary>
        [JsonProperty("ped", Required = Required.AllowNull)]
        public ShopPed PedInfo { get; set; }
        /// <summary>
        /// The modifications allowed by this shop.
        /// </summary>
        [JsonProperty("mods", Required = Required.Always)]
        public List<string> Mods { get; set; } = new List<string>();
        /// <summary>
        /// The list of vehicles that are whitelisted to use this menu.
        /// </summary>
        [JsonProperty("whitelist", Required = Required.Always)]
        public List<int> Whitelist { get; set; } = new List<int>();
        /// <summary>
        /// The list of vehicles that are blacklisted from using this menu.
        /// </summary>
        [JsonProperty("blacklist", Required = Required.Always)]
        public List<int> Blacklist { get; set; } = new List<int>();

        /// <summary>
        /// The menu used at this location.
        /// </summary>
        [JsonIgnore]
        public Menu Menu { get; internal set; }
        /// <summary>
        /// The Blip used to mark the location of the Food Shop.
        /// </summary>
        [JsonIgnore]
        public Blip Blip { get; internal set; }
        /// <summary>
        /// The Ped over the counter that speaks with the player.
        /// </summary>
        [JsonIgnore]
        public Ped Ped { get; internal set; }

        /// <summary>
        /// Clears the vehicles near the vehicle tuning location.
        /// </summary>
        public void ClearNearby()
        {
            Vehicle playerVehicle = Game.Player.Character.CurrentVehicle;
            Vehicle[] vehicles = World.GetNearbyVehicles(VehiclePos, TriggerSize);

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != playerVehicle)
                {
                    vehicle.Delete();
                }
            }
        }
    }
}
