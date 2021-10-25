using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;

namespace Cosmo.ActionTypes
{
    public class ConsoleCommand : IActionType
    {
        public struct ConsoleCommandData
        {
            [JsonProperty("cmd")] public string Command { get; set; }

            [JsonProperty("expire_cmd")] public string ExpireCommand { get; set; }
        }

        public string Name => "console_command";

        public Task Run(ActionPayload payload)
        {
            var data = payload.Data.ToObject<ConsoleCommandData>();

            var command = data.Command
                .Replace(":sid64", payload.SteamId)
                .Replace(":nick", payload.Player.Name);

            API.ExecuteCommand(command);

            return Task.FromResult(0);
        }

        public Task RunExpired(ActionPayload payload)
        {
            var data = payload.Data.ToObject<ConsoleCommandData>();

            var command = data.ExpireCommand
                .Replace(":sid64", payload.SteamId)
                .Replace(":nick", payload.Player.Name);

            BaseScript.TriggerEvent(command);

            return Task.FromResult(0);
        }
    }
}
