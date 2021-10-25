using CitizenFX.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Cosmo.ActionTypes
{
    public class EventTrigger : IActionType
    {
        public struct EventTriggerData
        {
            [JsonProperty("event")] public string Event { get; set; }
        }

        public string Name => "event_trigger";

        public Task Run(ActionPayload payload)
        {
            var data = payload.Data.ToObject<EventTriggerData>();

            BaseScript.TriggerEvent(data.Event);

            return Task.FromResult(0);
        }

        public Task RunExpired(ActionPayload payload)
        {
            var data = payload.Data.ToObject<EventTriggerData>();

            BaseScript.TriggerEvent(data.Event);

            return Task.FromResult(0);
        }
    }
}
