using GTA;
using GTA.Math;
using GTA.Native;
using Newtonsoft.Json;
using System.Collections.Generic;
using TuningShops.Converters;

namespace TuningShops
{
    /// <summary>
    /// Represents the location of a tuning shop.
    /// </summary>
    public class ShopLocation
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
        public MainMenu Menu { get; internal set; }
        /// <summary>
        /// The Blip used to mark the location of the Food Shop.
        /// </summary>
        [JsonIgnore]
        public Blip Blip { get; private set; }
        /// <summary>
        /// The Ped over the counter that speaks with the player.
        /// </summary>
        [JsonIgnore]
        public Ped Ped { get; private set; }

        /// <summary>
        /// Initializes the Entities and Camera.
        /// </summary>
        public void Initialize()
        {
            // Request the ped and create it
            if (PedInfo != null)
            {
                PedInfo.Model.Request();
                while (!PedInfo.Model.IsLoaded)
                {
                    Script.Yield();
                }
                Ped = World.CreatePed(PedInfo.Model, PedInfo.Position, PedInfo.Heading);
                Ped.IsPositionFrozen = true;
                Ped.BlockPermanentEvents = true;
                Ped.CanBeTargetted = false;
                Ped.CanRagdoll = false;
                Ped.CanWrithe = false;
                Ped.IsInvincible = true;
                PedInfo.Model.MarkAsNoLongerNeeded();
            }

            // Then, create the blip of the Food Shop
            Blip = World.CreateBlip(Trigger);
            Blip.Sprite = BlipSprite.LosSantosCustoms;
            Function.Call(Hash.SET_BLIP_COLOUR, Blip, (192 << 24) + (157 << 16) + (227 << 8) + 255);
            Blip.Name = $"Tuning Shop: {Name}";
            Blip.IsShortRange = true;
        }
        /// <summary>
        /// Cleans up the entities and camera.
        /// </summary>
        public void DoCleanup()
        {
            Ped?.Delete();
            Blip?.Delete();
        }
    }
}
