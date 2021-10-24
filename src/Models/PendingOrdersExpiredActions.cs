using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cosmo.Models
{
    public struct PendingOrdersExpiredActions
    {
        [JsonProperty("orders")] public IReadOnlyList<Order> PendingOrders { get; set; }
        
        [JsonProperty("actions")] public IReadOnlyList<Action> ExpiredActions { get; set; }
    }
}
