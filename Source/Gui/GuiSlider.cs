using System;
using UnityEngine;

namespace BSGod.Gui
{
    public class GuiSlider : IGui
    {
        private float _currentValue;
        private float _previousValue;

        private Rect _rect;
        private float _minValue;
        private float _maxValue;

        public event Action<float> OnValueChanged;

        public GuiSlider(Rect rect, float minValue, float maxValue)
        {
            _rect = rect;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public void Draw()
        {
            _currentValue = GUI.HorizontalSlider(_rect, _currentValue, _minValue, _maxValue);
            if(_currentValue != _previousValue)
            {
                if(OnValueChanged != null)
                {
                    OnValueChanged.Invoke(_currentValue);
                }
            }
        }
    }
}
