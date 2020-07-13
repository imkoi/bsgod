using BSGod.Managers;
using UnityEngine;

namespace BSGod.Hacks
{
    public class FlyHackModule : BaseHackModule
    {
        private BsGodPlayerManager _playerManager;
        private const float DefaultSpeed = 2f;
        private float _previousSpeed;

        public FlyHackModule(BsGodPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            var myPlayer = _playerManager.localPlayer;

            if (myPlayer != null)
            {
                myPlayer.source.fallingTime = 0;
                myPlayer.source.fallingTime.ApplyNewCryptoKey();


                var dt = Time.deltaTime;
                var direction = new Vector3(0, 1, 0);

                if (Input.GetKey(KeyCode.Space))
                {
                    myPlayer.characterController.Move(direction * _previousSpeed * dt);
                    _previousSpeed += DefaultSpeed;
                }
                else
                {
                    _previousSpeed = 0;
                }
            }
        }
    }
}
