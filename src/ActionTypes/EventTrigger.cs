using CitizenFX.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var obj = (JObject)payload.Data;
            var data = obj.ToObject<EventTriggerData>();

            BaseScript.TriggerEvent(data.Event);

            return Task.FromResult(0);
        }

        public Task RunExpired(ActionPayload payload)
        {
            var obj = (JObject)payload.Data;
            var data = obj.ToObject<EventTriggerData>();

            BaseScript.TriggerEvent(data.Event);

            return Task.FromResult(0);
        }
    }
}
