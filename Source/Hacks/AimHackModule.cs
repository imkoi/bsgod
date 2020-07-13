using BSGod.Data;
using BSGod.Managers;
using UnityEngine;

namespace BSGod.Hacks
{
    public class AimHackModule : BaseHackModule
    {
        private BsGodPlayerManager _playerManager;

        public AimHackModule(BsGodPlayerManager playerManager)
        {
            _playerManager = playerManager;
            OnActiveStateChanged += ActiveStateChanged;
        }

        public override void Execute()
        {
            var myPlayer = _playerManager.localPlayer;
            var remotePlayers = _playerManager.remotePlayers;

            if(myPlayer != null && remotePlayers != null && remotePlayers.Length > 0)
            {
                var cameraPosition = myPlayer.camera.transform.position;
                foreach (var player in remotePlayers)
                {
                    if (!player.isInvinsible)
                    {
                        var distance = GetDistanceToPlayer(cameraPosition, player);
                        var headD = BsPlayer.HeadDefaultSize / 2;
                        player.headCollider.radius = (headD + distance) / 2;
                    }
                    else
                    {
                        player.headCollider.radius = BsPlayer.HeadDefaultSize;
                    }
                }
            }
        }

        private float GetDistanceToPlayer(Vector3 origin, BsPlayer player)
        {
            return Vector3.Distance(origin, player.headTransform.position);
        }

        private BsPlayer GetClosestPlayer(Vector3 position, BsPlayer[] players)
        {
            if (players.Length > 0)
            {
                var closestPlayer = players[0];
                var closestPlayerDistance = Vector3.Distance(position, closestPlayer.headTransform.position);

                foreach (var suspectPlayer in players)
                {
                    var distanceToCamera = Vector3.Distance(position, suspectPlayer.headTransform.position);
                    if (distanceToCamera < closestPlayerDistance)
                    {
                        closestPlayer = suspectPlayer;
                        closestPlayerDistance = distanceToCamera;
                    }
                }

                return closestPlayer;
            }
            else
            {
                return null;
            }
        }

        private void ActiveStateChanged(bool isActive)
        {
            if (!isActive)
            {
                var myPlayer = _playerManager.localPlayer;
                var remotePlayers = _playerManager.remotePlayers;

                if (myPlayer != null && remotePlayers != null && remotePlayers.Length > 0)
                {
                    foreach (var player in remotePlayers)
                    {
                        player.headCollider.radius = BsPlayer.HeadDefaultSize;
                    }
                }
            }
        }
    }
}
