namespace Cosmo
{
    public struct ActionPayload
    {
        public ulong OrderId { get; set; }
        public string PackageName { get; set; }
        public string SteamId { get; set; }
        public object Data { get; set; }
    }
}
