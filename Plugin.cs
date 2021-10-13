using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Timers;
using System.Linq;
using Cosmo.Extensions;

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
            if (API.GetCurrentResourceName() != resourceName) return;

            Console.WriteLine("Started resource");
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
