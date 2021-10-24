using System;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using Cosmo.Controllers;

namespace Cosmo
{
    public class Plugin : BaseScript
    {
        private readonly IReadOnlyList<IController> _controllers;

        private Config Config { get; set; }

        public Plugin()
        {
            var controllerInterface = typeof(IController);

            _controllers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => controllerInterface.IsAssignableFrom(t) && t != controllerInterface)
                .Select(t => Activator.CreateInstance(t))
                .Cast<IController>()
                .ToList();

            EventHandlers["onResourceStart"] += new Action<string>(OnResourceStart);
        }

        private async void OnResourceStart(string resourceName)
        {
            if (API.GetCurrentResourceName() != resourceName) return;

            Config = LoadConfig();

            var controllerTasks = _controllers
                .Select(c => c.OnResourceStart(Config));

            await Task.WhenAll(controllerTasks);

            Debug.WriteLine("Started Cosmo FiveM integration.");
        }

        /// <summary>
        /// Attempts to read config from config/config.json.
        /// If fails to read file or parse json, it returns the <see cref="Config.Default">default config</see>
        /// </summary>
        /// <returns>Read config is succesful, default if failed</returns>
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
                    Debug.WriteLine("[Cosmo] [ERROR] Details: " + ex.Message);
                }
            }

            return config;
        }
    }
}
