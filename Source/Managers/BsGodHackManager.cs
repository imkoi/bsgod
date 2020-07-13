using BSGod.Hacks;
using UnityEngine;

namespace BSGod.Managers
{
    public class BsGodHackManager
    {
        private readonly BsGodGuiManager _guiManager;
        private readonly BsGodPlayerManager _playerManager;

        private readonly BaseHackModule _wallHackModule;
        private readonly BaseHackModule _aimHackModule;
        private readonly BaseHackModule _speedHackModule;
        private readonly BaseHackModule _flyHackModule;
        private readonly BaseHackModule _recoilHackModule;

        private BaseHackModule[] _hackModules;

        public BsGodHackManager(BsGodGuiManager guiManager, BsGodPlayerManager playerManager)
        {
            _guiManager = guiManager;
            _playerManager = playerManager;

            _wallHackModule = new WallHackModule(_playerManager);
            _aimHackModule = new AimHackModule(_playerManager);
            _speedHackModule = new SpeedHackModule(_playerManager);
            _flyHackModule = new FlyHackModule(_playerManager);
            _recoilHackModule = new RecoilHackModule(_playerManager);

            _guiManager.OnAimHackClicked += OnAimHackClicked;
            _guiManager.OnWallHackClicked += OnWallHackClicked;
            _guiManager.OnSpeedHackClicked += OnSpeedHackClicked;
            _guiManager.OnFlyHackClicked += OnFlyHackClicked;
            _guiManager.OnRecoilHackClicked += OnRecoilHackClicked;
            
            _hackModules = new BaseHackModule[]
            {
                _wallHackModule,
                _aimHackModule,
                _flyHackModule,
                _speedHackModule,
                _recoilHackModule,
            };
        }

        public void Process()
        {
            foreach(var hack in _hackModules)
            {
                if (hack.isActive)
                {
                    hack.Execute();
                }
            }
        }

        private void OnAimHackClicked(bool invoked)
        {
            _aimHackModule.ChangeActiveState();
        }

        private void OnWallHackClicked(bool invoked)
        {
            _wallHackModule.ChangeActiveState();
        }

        private void OnSpeedHackClicked(bool invoked)
        {
            _speedHackModule.ChangeActiveState();
        }

        private void OnFlyHackClicked(bool invoked)
        {
            _flyHackModule.ChangeActiveState();
        }

        private void OnRecoilHackClicked(bool invoked)
        {
            _recoilHackModule.ChangeActiveState();
        }
    }
}
