using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exiled.API.Features;
using PlayerEv = Exiled.Events.Handlers.Player;
using ServerEv = Exiled.Events.Handlers.Server;

namespace VIPBroadcast
{

    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; } = null;
        
        public override string Name => "VIP Broadcast";

        public override string Author => "TtroubleTT";

        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }
    }
}
