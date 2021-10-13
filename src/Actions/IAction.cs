using System.Threading.Tasks;

namespace Cosmo.Actions
{
    public interface IAction<T> where T : struct
    {
        public string ActionName { get; }
        public Task Run(ActionPayload<T> payload);
        public Task RunExpired(ActionPayload<T> payload);
    }
}
