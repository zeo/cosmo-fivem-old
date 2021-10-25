using CitizenFX.Core;
using Newtonsoft.Json.Linq;

namespace Cosmo.ActionTypes
{
    public struct ActionPayload
    {
        public ulong OrderId { get; set; }
        public string PackageName { get; set; }
        public Player Player { get; set; }
        public string SteamId { get; set; }
        public JObject Data { get; set; } // Only JObject temporarily until payloads get refactored.
    }
}
