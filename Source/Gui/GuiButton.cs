using System;
using UnityEngine;

namespace BSGod.Gui
{
    public class GuiButton : IGui
    {
        private bool _isEnabled;
        private Color32 _disabledColor = Color.white;
        private Color32 _enabledColor = Color.red;

        private Rect _rect;
        private Color32 _color;
        private string _text;

        public event Action<bool> OnButtonClicked;

        public GuiButton(Rect rect, string text)
        {
            _rect = rect;
            _color = _disabledColor;
            _text = text;
        }

        public GuiButton(Rect rect, Color32 color)
        {
            _rect = rect;
            _color = color;
        }

        public void Draw()
        {
            GUI.color = _color;

            if (string.IsNullOrEmpty(_text))
            {
                if (GUI.Button(_rect, string.Empty))
                {
                    if (OnButtonClicked != null)
                    {
                        OnButtonClicked.Invoke(_isEnabled);
                    }
                }
            }
            else
            {
                if (GUI.Button(_rect, _text))
                {
                    ButtonClick();
                }
            }
        }

        private void ButtonClick()
        {
            if (OnButtonClicked != null)
            {
                SwitchColor();
                OnButtonClicked.Invoke(_isEnabled);
            }
        }

        private void SwitchColor()
        {
            _isEnabled = !_isEnabled;

            if (_isEnabled)
            {
                _color = _enabledColor;
            }
            else
            {
                _color = _disabledColor;
            }
        }
    }
}
