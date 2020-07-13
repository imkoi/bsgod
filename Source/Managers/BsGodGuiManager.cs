using BSGod.Gui;
using System;
using UnityEngine;

namespace BSGod.Managers
{
    public class BsGodGuiManager
    {
        private const string MenuTextName = "BS GOD v1.0.1";
        private const string AuthorTextName = "by Koi";
        private const string AimHackButtonName = "Aim Hack";
        private const string WallHackButtonName = "Wall Hack";
        private const string SpeedHackButtonName = "Speed Hack";
        private const string FlyHackButtonName = "Fly Hack";
        private const string RecoilHackButtonName = "Recoil Hack [WIP]";

        private IGui[] _guis;

        private GuiPanel _menuPanel;
        private GuiText _menuText;
        private GuiText _authorText;

        private GuiButton _wallHackButton;
        private GuiButton _aimHackButton;
        private GuiButton _speedHackButton;
        private GuiButton _flyHackButton;
        private GuiButton _recoilHackButton;
        private GuiText _statusText;

        public event Action<bool> OnWallHackClicked;
        public event Action<bool> OnAimHackClicked;
        public event Action<bool> OnSpeedHackClicked;
        public event Action<bool> OnFlyHackClicked;
        public event Action<bool> OnRecoilHackClicked;

        public BsGodGuiManager()
        {
            SetupGui();

            _guis = new IGui[]
            {
                _menuPanel,
                _menuText,
                _authorText,

                _wallHackButton,
                _aimHackButton,
                _speedHackButton,
                _flyHackButton,
                _recoilHackButton,

                _statusText,
            };
        }

        public void WriteStatus(string text)
        {
            _statusText.text = text;
        }

        public void Draw()
        {
            foreach(var gui in _guis)
            {
                gui.Draw();
            }
        }

        private void SetupGui()
        {
            _menuPanel = new GuiPanel(new Rect(20, 240, 200, 190), Color.red);
            _menuText = new GuiText(new Rect(75, 240, 180, 20), Color.red, MenuTextName);
            _authorText = new GuiText(new Rect(100, 257, 180, 20), Color.white, AuthorTextName);

            _wallHackButton = new GuiButton(new Rect(30, 280, 180, 20), WallHackButtonName);
            _aimHackButton = new GuiButton(new Rect(30, 310, 180, 20), AimHackButtonName);
            _speedHackButton = new GuiButton(new Rect(30, 340, 180, 20), SpeedHackButtonName);
            _flyHackButton = new GuiButton(new Rect(30, 370, 180, 20), FlyHackButtonName);
            _recoilHackButton = new GuiButton(new Rect(30, 400, 180, 20), RecoilHackButtonName);

            _statusText = new GuiText(new Rect(5, 5, 640, 20), Color.white, "Info");

            _wallHackButton.OnButtonClicked += OnWallHackButtonClicked;
            _aimHackButton.OnButtonClicked += OnAimHackButtonClicked;
            _speedHackButton.OnButtonClicked += OnSpeedHackButtonClicked;
            _flyHackButton.OnButtonClicked += OnFlyHackButtonClicked;
            _recoilHackButton.OnButtonClicked += OnRecoilHackButtonClicked;
        }

        private void OnAimHackButtonClicked(bool invoked)
        {
            if (OnAimHackClicked != null)
            {
                OnAimHackClicked.Invoke(invoked);
            }
        }

        private void OnWallHackButtonClicked(bool invoked)
        {
            if (OnWallHackClicked != null)
            {
                OnWallHackClicked.Invoke(invoked);
            }
        }

        private void OnSpeedHackButtonClicked(bool invoked)
        {
            if (OnSpeedHackClicked != null)
            {
                OnSpeedHackClicked.Invoke(invoked);
            }
        }

        private void OnFlyHackButtonClicked(bool invoked)
        {
            if(OnFlyHackClicked != null)
            {
                OnFlyHackClicked.Invoke(invoked);
            }
        }

        private void OnRecoilHackButtonClicked(bool invoked)
        {
            if(OnRecoilHackClicked != null)
            {
                OnRecoilHackClicked.Invoke(invoked);
            }
        }
    }
}
