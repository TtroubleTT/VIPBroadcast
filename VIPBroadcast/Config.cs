using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace VIPBroadcast
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug Config.")]
        public bool Debug { get; set; } = true;

        [Description("How long the vip broadcast should last.")]
        public static ushort BroadcastLength { get; set; } = 5;

        [Description("How long the cooldown should be until they can send another message.")]
        public static float MessageCooldown { get; set; } = 10f;
    }
}
