using Newtonsoft.Json;
using System;

namespace IQVATest
{
    public class Tweet
    {
        /// <summary>
        /// id of Tweet
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("stamp")]
        public DateTime stamp { get; set; }

        /// <summary>
        /// text of tweet
        /// </summary>
        [JsonProperty("text")]
        public string text { get; set; }
    }
   
}
