using System.Threading.Tasks;

namespace Cosmo.ActionTypes
{
    public interface IActionType
    {
        public string Name { get; }

        public Task Run(ActionPayload payload);
        public Task RunExpired(ActionPayload payload);
    }
}
