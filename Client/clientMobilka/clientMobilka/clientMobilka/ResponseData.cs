using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace clientMobilka
{
    public class ResponseData
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<Dictionary<string, object>> Data { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
