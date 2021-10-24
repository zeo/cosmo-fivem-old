﻿namespace Cosmo.Models
{
    public struct Action
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Receiver { get; set; }
        public object Data { get; set; }

#nullable enable
        public Order? Order { get; set; }
#nullable disable
    }
}
