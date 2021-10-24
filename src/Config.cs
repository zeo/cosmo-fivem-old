using Newtonsoft.Json;

namespace Cosmo
{
    public struct Config
    {
        /// <summary>
        /// The URL of the Cosmo instance
        /// </summary>
        [JsonProperty("instance_url")] public string InstanceUrl { get; set; }

        /// <summary>
        /// The server token used to make API calls to the instance url
        /// </summary>
        [JsonProperty("server_token")] public string ServerToken { get; set; }

        /// <summary>
        /// The interval in seconds at which the plugin checks for
        /// pending orders / expired actions.
        /// </summary>
        [JsonProperty("fetch_interval")] public int FetchInterval { get; set; }


        /// <summary>
        /// The default config
        /// </summary>
        public static Config Default => new Config
        {
            InstanceUrl = "your.domain",
            ServerToken = "",
            FetchInterval = 60,
        };
    }
}
