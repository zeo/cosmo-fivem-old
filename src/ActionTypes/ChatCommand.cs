using System.Threading.Tasks;

namespace Cosmo.ActionTypes
{
    public class ChatCommand : IActionType
    {
        public string Name => "chat_command";

        public Task Run(ActionPayload payload)
        {
            throw new System.NotImplementedException();
        }

        public Task RunExpired(ActionPayload payload)
        {
            throw new System.NotImplementedException();
        }
    }
}
