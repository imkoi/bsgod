using UnityEngine;

namespace BSGod.Gui
{
    class GuiText : IGui
    {
        private Rect _rect;
        private Color32 _color;

        public string text;

        public GuiText(Rect rect, Color32 color, string text)
        {
            _rect = rect;
            _color = color;

            this.text = text;
        }
        
        public void Draw()
        {
            GUI.color = _color;
            GUI.Label(_rect, text);
        }
    }
}
