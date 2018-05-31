using System.IO;

using Newtonsoft.Json;

using RestSharp.Serializers;

using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace RestSharpExample.HLHttpClient.Serializers
{
    public class NewtonsoftSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public NewtonsoftSerializer()
        {
            ContentType = "application/json";
            _serializer = new JsonSerializer()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public NewtonsoftSerializer(JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';
                    _serializer.Serialize(jsonTextWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }
    }
}