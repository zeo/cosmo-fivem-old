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
            var curResource = API.GetCurrentResourceName();
            if (curResource != resourceName) return;

            var configRaw = API.LoadResourceFile(curResource, "config/config.json");
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

                return;
            }

            Debug.WriteLine("Database password is: " + config.Database.Password);
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
