using CitizenFX.Core;
using System.Linq;

namespace Cosmo.Extensions
{
    public static class PlayerExtensions
    {
        public static string GetSteamId(this Player player)
        {
            return player.Identifiers
                .FirstOrDefault(i => i.StartsWith("steam:"))
                .Substring("steam:".Length);
        }
    }
}
