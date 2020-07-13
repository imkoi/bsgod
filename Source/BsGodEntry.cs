using BSGod.Data;
using BSGod.Managers;
using System;
using UnityEngine;

namespace BSGod
{
    public class BsGodEntry : MonoBehaviour
    {
        private BsGodPlayerManager _playerManager;
        private BsGodInputManager _inputManager;
        private BsGodGuiManager _guiManager;
        private BsGodHackManager _hackManager;

        private bool _shouldShowGui;

        private void Awake()
        {
            _inputManager = new BsGodInputManager();
            _guiManager = new BsGodGuiManager();

            _playerManager = new BsGodPlayerManager(_guiManager);
            _hackManager = new BsGodHackManager(_guiManager, _playerManager);

            _inputManager.OnGuiStateChanged += OnGuiStateChanged;
        }

        private void Update()
        {
            if(_inputManager != null)
            {
                _inputManager.Process();
            }
            else
            {
                throw new Exception("_inputManager == null");
            }

            if (_playerManager != null)
            {
                _playerManager.Process();
            }
            else
            {
                throw new Exception("_playerManager == null");
            }
        }

        private void LateUpdate()
        {
            if(_hackManager != null)
            {
                _hackManager.Process();
            }
            else
            {
                throw new Exception("_hackManager == null");
            }
        }

        private void OnGUI()
        {
            if (_shouldShowGui)
            {
                if (_guiManager != null)
                {
                    _guiManager.Draw();
                }
                else
                {
                    throw new Exception("_guiManager == null");
                }
            }
        }

        private void OnGuiStateChanged(bool invoked)
        {
            _shouldShowGui = !_shouldShowGui;
            GUI.enabled = _shouldShowGui;
        }
    }
}
