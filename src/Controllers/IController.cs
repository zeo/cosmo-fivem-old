using System.Threading.Tasks;

namespace Cosmo.Controllers
{
    public interface IController
    {
        public Task OnResourceStart(Config config);
    }
}
