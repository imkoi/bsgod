using UnityEngine;

namespace BSGod
{
    public static class BsGodInjector
    {
        public static void Inject()
        {
            var bsGodHandler = new GameObject("BsGodHandler");
            bsGodHandler.AddComponent<BsGodEntry>();
            Object.DontDestroyOnLoad(bsGodHandler);
        }
    }
}
