using System.Collections.Generic;

namespace Cosmo.Models
{
    public struct PendingOrdersExpiredActions
    {
        public IReadOnlyList<Order> PendingOrders { get; set; }
        public IReadOnlyList<Action> ExpiredActions { get; set; }
    }
}
