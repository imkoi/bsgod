using System;

namespace BSGod.Hacks
{
    public abstract class BaseHackModule
    {
        protected event Action<bool> OnActiveStateChanged;
        public bool isActive { get; protected set; }

        public abstract void Execute();

        public void ChangeActiveState()
        {
            if (OnActiveStateChanged != null)
            {
                OnActiveStateChanged.Invoke(!isActive);
            }
            isActive = !isActive;
        }
    }
}
