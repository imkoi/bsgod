using System.Runtime.InteropServices;
using UnityEngine;

namespace BSGod
{
    public static class BsGodInputRaiser
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void ClickMouseButton(int button)
        {
            uint mouseDown = 0;
            uint mouseUp = 0;

            switch (button)
            {
                case 0:
                    mouseDown = MOUSEEVENTF_LEFTDOWN;
                    mouseUp = MOUSEEVENTF_LEFTUP;
                    break;
                case 1:
                    mouseDown = MOUSEEVENTF_RIGHTDOWN;
                    mouseUp = MOUSEEVENTF_RIGHTUP;
                    break;
            }

            var mousePosition = Input.mousePosition;

            uint x = (uint)mousePosition.x;
            uint y = (uint)mousePosition.y;
            mouse_event(mouseDown | mouseUp, x, y, 0, 0);
        }
    }
}
