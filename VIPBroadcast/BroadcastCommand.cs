using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace VIPBroadcast
{

    [CommandHandler(typeof(ClientCommandHandler))]
    public class GiveRoomType : ICommand
    {
        private Dictionary<Player, DateTime> Cooldown { get; } = new Dictionary<Player, DateTime>();

        public string Command => "vipbroadcast";

        public string[] Aliases => new[] { "broadcast" };

        public string Description => "Broadcasts a message to the entire server.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("pc.vipbroadcast"))
            {
                response = "Permission denied.";

                return false;
            }

            Player player = Player.Get(sender);
            if (Cooldown.ContainsKey(player) && DateTime.Now < Cooldown[player])
            {
                response = $"This command is still on cooldown. Try again in {(Cooldown[player] - DateTime.Now).TotalSeconds} seconds.";

                return false;
            }

            Cooldown[player] = DateTime.Now.AddSeconds(Plugin.Instance.Config.MessageCooldown);

            string message = string.Empty;
            foreach (string s in arguments)
                message += $"{s} ";
            message = message.TrimEnd(' ');

            Map.Broadcast(Plugin.Instance.Config.BroadcastLength, message);
            response = $"Broadcast sent.";
            return true;
        }
    }
}
