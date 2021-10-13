using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmo.Actions
{
    public interface IAction<T>
    {
        public string ActionName { get; }
        public Task Run(ActionPayload<T> payload);
        public Task RunExpired(ActionPayload<T> payload);
    }
}
