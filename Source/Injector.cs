using UnityEngine;

namespace BSGod
{
    public static class Injector
    {
        public static void Inject()
        {
            var bsGodHandler = new GameObject("BsGodHandler");
            bsGodHandler.AddComponent<BsGodEntry>();
            Object.DontDestroyOnLoad(bsGodHandler);
        }
    }
}
