using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Useful.ForecastRepository.Converters
{
    public class ObjectIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null && value.GetType().IsArray)
            {
                writer.WriteStartArray();
                foreach (var item in (Array) value) serializer.Serialize(writer, item);
                writer.WriteEndArray();
            }
            else
            {
                serializer.Serialize(writer, value?.ToString());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var objectIds = new List<ObjectId>();

            if (token.Type == JTokenType.Array)
            {
                objectIds.AddRange(token.ToObject<string[]>().Select(item => new ObjectId(item)));
                return objectIds.ToArray();
            }

            if (token.ToObject<string>().Equals("MongoDB.Bson.ObjectId[]"))
            {
                return objectIds.ToArray();
            }

            return new ObjectId(token.ToObject<string>());
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectId);
        }
    }
}