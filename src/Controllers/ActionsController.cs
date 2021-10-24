using CitizenFX.Core;
using Cosmo.Actions;
using Cosmo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace Cosmo.Controllers
{
    public class ActionsController : IController
    {
        private readonly IReadOnlyDictionary<string, IActionType> _actionTypes;

        private HttpClient Http;
        private Timer Timer;

        public ActionsController()
        {
            _actionTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IActionType).IsAssignableFrom(t) && t != typeof(IActionType))
                .Select(t => Activator.CreateInstance(t))
                .Cast<IActionType>()
                .ToDictionary(k => k.Name);
        }

        public Task OnResourceStart(Config config)
        {
            Http = new HttpClient(config);

            Timer = new Timer(config.FetchInterval * 1000);
            Timer.Enabled = true;
            Timer.AutoReset = true;
            Timer.Elapsed += async (object src, ElapsedEventArgs args) => await FetchPending();

            return Task.Run(() => { });
        }

        private async Task FetchPending()
        {
            var result = await Http.GetPendingOrdersAndExpiredActions();

            foreach (var order in result.PendingOrders)
            {
                if (order.Actions == null) continue;

                Debug.WriteLine("Handling pending order: " + order.Id);

                foreach (var action in order.Actions)
                {
                    Debug.WriteLine("Handling action: " + action.Id);
                
                    if (!_actionTypes.TryGetValue(action.Name, out var actionType))
                    {
                        Debug.WriteLine("Invalid action type");
                        continue;
                    }

                    var payload = new ActionPayload
                    {
                        OrderId = order.Id,
                        PackageName = order.PackageName,
                        SteamId = action.Receiver,
                        Data = action.Data
                    };

                    await actionType.Run(payload);

                    await Http.CompleteAction(action.Id);
                }

                await Http.DeliverOrder(order.Id);
            }

            foreach (var action in result.ExpiredActions)
            {
                if (!_actionTypes.TryGetValue(action.Name, out var actionType))
                {
                    Debug.WriteLine("Invalid action type.");
                    continue;
                }

                var payload = new ActionPayload
                {
                    OrderId = 1,
                    PackageName = action.Order.Value!.PackageName,
                    SteamId = action.Receiver,
                    Data = action.Data
                };

                await actionType.RunExpired(payload);

                await Http.ExpireAction(action.Id);
            }
        }
    }
}
