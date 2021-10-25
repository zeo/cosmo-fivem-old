using CitizenFX.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Cosmo.ActionTypes
{
    public class ChatCommand : IActionType
    {
        public struct ChatCommandData
        {
            [JsonProperty("cmd")] public string Command { get; set; }

            [JsonProperty("expire_cmd")] public string ExpireCommand { get; set; }
        }

        public string Name => "chat_command";

        public Task Run(ActionPayload payload)
        {
            var data = payload.Data.ToObject<ChatCommandData>();

            BaseScript.TriggerEvent("chat:addMessage", new
            {
                args = new[] { data.Command }
            });

            return Task.FromResult(0);
        }

        public Task RunExpired(ActionPayload payload)
        {
            var data = payload.Data.ToObject<ChatCommandData>();

            BaseScript.TriggerEvent("chat:addMessage", new
            {
                args = new[] { data.ExpireCommand }
            });

            return Task.FromResult(0);
        }
    }
}
