using System.Threading.Tasks;
using CitizenFX.Core;

namespace Cosmo.Actions
{
    public class ConsoleCommand : IAction<ConsoleCommand.ConsoleCommandData>
    {
        public struct ConsoleCommandData
        {
            public string Command { get; set; }
            public string ExpireCommand { get; set; }
        }

        public string ActionName => "console_command";

        public Task Run(ActionPayload<ConsoleCommandData> payload)
        {
            var command = payload.Data.Command;

            BaseScript.TriggerEvent(command);

            return Task.Run(() => { });
        }

        public Task RunExpired(ActionPayload<ConsoleCommandData> payload)
        {
            return Task.Run(() => { });
        }
    }
}
