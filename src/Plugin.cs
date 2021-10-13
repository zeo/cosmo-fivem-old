using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Timers;
using System.Linq;
using Cosmo.Extensions;
using Newtonsoft.Json;

namespace Cosmo
{
    public class Plugin : BaseScript
    {
        private readonly Timer _timer;

        public static Config Config { get; private set; }

        public Plugin()
        {
            _timer = new Timer(2000);
            _timer.AutoReset = true;
            _timer.Elapsed += (object src, ElapsedEventArgs args) => CheckPendingActions();
            _timer.Enabled = true;

            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
        }

        private void OnResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName) return;

            Config = LoadConfig();

            Debug.WriteLine("Database password is: " + Config.Database.Password);
        }

        private static Config LoadConfig()
        {
            var configRaw = API.LoadResourceFile(API.GetCurrentResourceName(), "config/config.json");
            var config = Config.Default;

            if (configRaw != null)
            {
                try
                {
                    config = JsonConvert.DeserializeObject<Config>(configRaw);
                }
                catch (JsonReaderException ex)
                {
                    Debug.WriteLine("[Cosmo] [ERROR] Invalid config.json file, reverting to default.");
                    Debug.WriteLine($"[Cosmo] [ERROR] Details: {ex.Message}");
                }
            }

            return config;
        }

        private void CheckPendingActions()
        {
            Console.WriteLine("Checking for pending actions.");

            var steamIds = Players.Select(p => p.GetSteamId()).ToList();
            foreach (var steamId in steamIds)
            {
                Console.WriteLine(steamId);
            }
        }
    }
}
