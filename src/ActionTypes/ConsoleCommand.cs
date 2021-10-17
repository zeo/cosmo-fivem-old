using System.Threading.Tasks;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace Cosmo.Actions
{
    public class ConsoleCommand : IActionType
    {
        public struct ConsoleCommandData
        {
            [JsonProperty("cmd")]
            public string Command { get; set; }

            [JsonProperty("expire_cmd")]
            public string ExpireCommand { get; set; }
        }

        public string Name => "console_command";

        public Task Run(ActionPayload payload)
        {
            var data = (ConsoleCommandData)payload.Data;
            var command = data.Command;

            BaseScript.TriggerEvent(command);

            return Task.Run(() => { });
        }

        public Task RunExpired(ActionPayload payload)
        {
            var data = (ConsoleCommandData)payload.Data;
            var command = data.ExpireCommand;

            BaseScript.TriggerEvent(command);

            return Task.Run(() => { });
        }
    }
}
