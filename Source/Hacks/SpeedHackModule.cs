using BSGod.Managers;
using UnityEngine;

namespace BSGod.Hacks
{
    public class SpeedHackModule : BaseHackModule
    {
        private BsGodPlayerManager _playerManager;

        public SpeedHackModule(BsGodPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            var myPlayer = _playerManager.localPlayer;
           
            if (myPlayer != null)
            {
                var cameraTransform = myPlayer.camera.transform;
                var dt = Time.deltaTime;

                var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                var direction = cameraTransform.forward * input.y + cameraTransform.right * input.x;
                if (direction.magnitude > 1)
                {
                    direction.Normalize();
                }

                myPlayer.characterController.Move(direction * 8f * dt);
            }
        }
    }
}
