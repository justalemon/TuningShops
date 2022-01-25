using GTA.Math;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TuningShops.Converters
{
    /// <summary>
    /// Converts a Vector3 to JSON and vice versa.
    /// </summary>
    internal class Vector3Converter : JsonConverter<Vector3?>
    {
        public override Vector3? ReadJson(JsonReader reader, Type objectType, Vector3? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject @object = JObject.Load(reader);
            float x = @object.ContainsKey("x") ? (float)@object["x"] : 0;
            float y = @object.ContainsKey("y") ? (float)@object["y"] : 0;
            float z = @object.ContainsKey("z") ? (float)@object["z"] : 0;
            return new Vector3(x, y, z);
        }

        public override void WriteJson(JsonWriter writer, Vector3? value, JsonSerializer serializer)
        {
            if (!value.HasValue)
            {
                writer.WriteNull();
                return;
            }

            JObject @object = new JObject
            {
                ["x"] = value.Value.X,
                ["y"] = value.Value.Y,
                ["z"] = value.Value.Z
            };
            @object.WriteTo(writer);
        }
    }
}
