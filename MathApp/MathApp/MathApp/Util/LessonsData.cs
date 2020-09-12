using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MathApp.Util
{
    public partial class LessonsData
    {
        [JsonProperty("Lessons")]
        public List<Lesson> Lessons { get; set; }
    }

    public partial class Lesson
    {
        [JsonProperty("Name")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Name { get; set; }

        [JsonProperty("Questions")]
        public List<Question> Questions { get; set; }
    }

    public partial class Question
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Options")]
        public List<string> Options { get; set; }
    }

    public partial class LessonsData
    {
        public static LessonsData FromJson(string json) => JsonConvert.DeserializeObject<LessonsData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this LessonsData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}