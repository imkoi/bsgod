using BSGod.Data;
using System.Collections.Generic;
using UnityEngine;

namespace BSGod.Managers
{
    public class BsGodPlayerManager
    {
        private readonly BsGodGuiManager _guiManager;

        public BsPlayer localPlayer;
        public BsPlayer[] remotePlayers;

        public BsGodPlayerManager(BsGodGuiManager guiManager)
        {
            _guiManager = guiManager;
        }

        public void Process()
        {
            var allPlayers = GetAllPlayers();

            if(allPlayers != null)
            {
                localPlayer = GetLocalPlayer(allPlayers);
                remotePlayers = GetRemotePlayers(allPlayers);
            }
            else
            {
                localPlayer = null;
                remotePlayers = null;
            }

            var localPlayerCount = localPlayer == null ? 0 : 1;
            var remotePlayersCount = remotePlayers == null ? 0 : remotePlayers.Length;
            var playersFounded = allPlayers != null ? allPlayers.Length > 0 : false;

            _guiManager.WriteStatus(string.Format("[local players: {0}] [remote players: {1}] []",
                localPlayerCount, remotePlayersCount));
        }

        private BsPlayer[] GetAllPlayers()
        {
            var blockstormChracters = Object.FindObjectsOfType<Character>();
            if(blockstormChracters != null)
            {
                var blockstormChractersCount = blockstormChracters.Length;

                var players = new List<BsPlayer>();
                for (var i = 0; i < blockstormChractersCount; i++)
                {
                    var suspectPlayer = BsPlayer.TryGetPlayer(blockstormChracters[i]);
                    if(suspectPlayer != null)
                    {
                        players.Add(suspectPlayer);
                    }
                }

                return players.ToArray();
            }

            return null;
        }

        private BsPlayer GetLocalPlayer(BsPlayer[] allPlayers)
        {
            var playersCount = allPlayers.Length;

            for (var i = 0; i < playersCount; i++)
            {
                var suspectPlayer = allPlayers[i];
                if (suspectPlayer.isMine)
                {
                    return suspectPlayer;
                }
            }

            return null;
        }

        private BsPlayer[] GetRemotePlayers(BsPlayer[] allPlayers)
        {
            var otherPlayers = new List<BsPlayer>();

            var playersCount = allPlayers.Length;
            for (var i = 0; i < playersCount; i++)
            {
                var suspectPlayer = allPlayers[i];
                if (!suspectPlayer.isMine)
                {
                    otherPlayers.Add(suspectPlayer);
                }
            }

            return otherPlayers.ToArray();
        }
    }
}
