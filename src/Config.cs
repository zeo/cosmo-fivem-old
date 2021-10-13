namespace Cosmo
{
    public struct Config
    {
        public struct DatabaseConfig
        {
            public string Host { get; set; }
            public string Username { get; set; }
            public string Password {  get; set; }
            public string Database { get; set; }
            public uint Port { get; set; }
        }

        /// <summary>
        /// The server identifier retrieved from the Cosmo management panel
        /// </summary>
        public ulong ServerId { get; set; }

        /// <summary>
        /// The interval at which the plugins checks the database for
        /// pending orders / expired actions.
        /// </summary>
        public uint FetchInterval { get; set; }

        public DatabaseConfig Database { get; set; }

        /// <summary>
        /// The default config
        /// </summary>
        public static Config Default => new Config
        {
            ServerId = 1,
            FetchInterval = 60,

            Database = new DatabaseConfig
            {
                Host = "localhost",
                Username = "root",
                Password = "Password1",
                Database = "cosmo",
                Port = 3306,
            }
        };
    }
}
