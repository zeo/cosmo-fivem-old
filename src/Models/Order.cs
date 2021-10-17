using System.Collections.Generic;

namespace Cosmo.Models
{
    public struct Order
    {
        public ulong Id { get; set; }
        public string Receiver { get; set; }
        public string PackageName { get; set; }

#nullable enable
        public IReadOnlyList<Action>? Actions { get; set; }
#nullable disable
    }
}
