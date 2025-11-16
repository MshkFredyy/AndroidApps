using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace clientMobilka
{
    public class RequestData
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("tableName")]
        public string TableName { get; set; }
    }
}
