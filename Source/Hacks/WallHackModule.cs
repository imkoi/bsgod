using BSGod.Managers;
using UnityEngine;

namespace BSGod.Hacks
{
    public class WallHackModule : BaseHackModule
    {
        private BsGodPlayerManager _playerManager;
        private Camera _wallHackCamera;
        private Transform _wallHackCameraTransform;

        public WallHackModule(BsGodPlayerManager playerManager)
        {
            _playerManager = playerManager;
            _wallHackCamera = CreateWallHackCamera();
            _wallHackCameraTransform = _wallHackCamera.transform;

            OnActiveStateChanged += OnStateChanged;
        }

        public override void Execute()
        {
            var myPlayer = _playerManager.localPlayer;
            var remotePlayers = _playerManager.remotePlayers;

            if (myPlayer != null && remotePlayers != null && remotePlayers.Length > 0)
            {
                _wallHackCamera.enabled = true;
                _wallHackCameraTransform.position = myPlayer.camera.transform.position;
                _wallHackCameraTransform.rotation = myPlayer.camera.transform.rotation;
                _wallHackCamera.fieldOfView = myPlayer.camera.fieldOfView;
                _wallHackCamera.cullingMask = remotePlayers[0].layerMask;
            }
        }

        private Camera CreateWallHackCamera()
        {
            var wallHackHandler = new GameObject("WallHackCamera");
            var camera = wallHackHandler.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.Depth;
            camera.enabled = false;
            Object.DontDestroyOnLoad(wallHackHandler);

            return camera;
        }

        private void OnStateChanged(bool isActive)
        {
            _wallHackCamera.enabled = false;
        }
    }
}
