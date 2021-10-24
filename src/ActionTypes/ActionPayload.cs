using CitizenFX.Core;

namespace Cosmo.ActionTypes
{
    public struct ActionPayload
    {
        public ulong OrderId { get; set; }
        public string PackageName { get; set; }
        public Player Player { get; set; }
        public string SteamId { get; set; }
        public object Data { get; set; }
    }
}
