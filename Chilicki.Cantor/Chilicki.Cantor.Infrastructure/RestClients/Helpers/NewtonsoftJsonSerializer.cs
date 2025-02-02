﻿using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace Chilicki.Cantor.Infrastructure.RestClients.Helpers
{
    public class NewtonsoftJsonSerializer : IDeserializer
    {
        private JsonSerializer serializer;

        public NewtonsoftJsonSerializer(JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static NewtonsoftJsonSerializer Default
        {
            get
            {
                return new NewtonsoftJsonSerializer(new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
        }
    }
}
