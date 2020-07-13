using UnityEngine;

namespace BSGod.Gui
{
    public class GuiPanel : IGui
    {
        private Rect _rect;
        private Color32 _color;
        private string _panelName;

        public GuiPanel(Rect rect, Color32 color, string panelName = null)
        {
            _rect = rect;
            _color = color;
            _panelName = panelName;
        }

        public void Draw()
        {
            GUI.color = _color;

            if (string.IsNullOrEmpty(_panelName))
            {
                GUI.Box(_rect, string.Empty);
            }
            else
            {
                GUI.Box(_rect, _panelName);
            }
        }
    }
}
