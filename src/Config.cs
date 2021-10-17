namespace Cosmo
{
    public struct Config
    {
        /// <summary>
        /// The URL of the Cosmo instance
        /// </summary>
        public string InstanceUrl { get; set; }

        /// <summary>
        /// The server token used to make API calls to the instance url
        /// </summary>
        public string ServerToken { get; set; }

        /// <summary>
        /// The interval in seconds at which the plugin checks for
        /// pending orders / expired actions.
        /// </summary>
        public uint FetchInterval { get; set; }


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
