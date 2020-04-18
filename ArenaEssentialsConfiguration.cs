using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaEssentials
{
    public class ArenaEssentialsConfiguration : IRocketPluginConfiguration
    {
        public bool VanishTimer;
        public int VanishTime;

        public void LoadDefaults()
        {
            VanishTimer = true;
            VanishTime = 10;
        }
    }
}
