﻿namespace Cosmo
{
    public struct ActionPayload<T> where T : struct
    {
        public ulong OrderId { get; set; }
        public string PackageName { get; set; }
        public string SteamId { get; set; }
        public T Data { get; set; }
    }
}
