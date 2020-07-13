using System;
using UnityEngine;

namespace BSGod.Managers
{
    public class BsGodInputManager
    {
        public event Action<bool> OnGuiStateChanged;

        public void Process()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                if (OnGuiStateChanged != null)
                {
                    OnGuiStateChanged.Invoke(true);
                }
            }
        }
    }
}
