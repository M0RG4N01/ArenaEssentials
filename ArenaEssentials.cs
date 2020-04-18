using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Rocket.Unturned.Enumerations;

namespace ArenaEssentials
{
    public class Main : RocketPlugin<ArenaEssentialsConfiguration>
    {
        public static Main Instance;

        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("Arena Essentials has been loaded!");
        }

        //private void test(UnturnedPlayer player, byte life)
        //{
        //    Rocket.Core.Logging.Logger.LogWarning("test");
        //    Arena(player.CSteamID, EArenaState.PLAY, EArenaMessage.PLAY);
        //}

        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("Arena Essentials has been unloaded!");
        }

        private void Arena(CSteamID ArenaID, EArenaState ArenaS, EArenaMessage ArenaM)
        {
            UnturnedPlayer ArenaP = UnturnedPlayer.FromCSteamID(ArenaID);
            System.Timers.Timer vTimer = new System.Timers.Timer();

            if (LevelManager.ArenaState == EArenaState.PLAY && Configuration.Instance.VanishTimer)
            {
                try
                {
                    UnturnedChat.Say("Players are vanished for " + " " + Configuration.Instance.VanishTime + " " + " seconds", Color.red);
                    ArenaP.Features.VanishMode = true;
                    vTimer.Interval = Configuration.Instance.VanishTime * 1000;
                    vTimer.Enabled = true;
                    ArenaP.Features.VanishMode = false;
                    vTimer.Enabled = false;
                }
                catch(Exception arg)
                {
                    Rocket.Core.Logging.Logger.LogError("Args: " + arg);
                }
            }
        }
    }
}
