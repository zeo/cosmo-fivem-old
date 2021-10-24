using System.Threading.Tasks;
using CitizenFX.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cosmo.Actions
{
    public class ConsoleCommand : IActionType
    {
        public struct ConsoleCommandData
        {
            [JsonProperty("cmd")] public string Command { get; set; }

            [JsonProperty("expire_cmd")] public string ExpireCommand { get; set; }
        }

        public string Name => "console_command";

        public async Task Run(ActionPayload payload)
        {
            var obj = (JObject)payload.Data;
            var data = obj.ToObject<ConsoleCommandData>();
            var command = data.Command;

            BaseScript.TriggerEvent(command);
        }

        public async Task RunExpired(ActionPayload payload)
        {
            var obj = (JObject)payload.Data;
            var data = obj.ToObject<ConsoleCommandData>();
            var command = data.ExpireCommand;

            BaseScript.TriggerEvent(command);
        }
    }
}
