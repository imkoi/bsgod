using BSGod.Managers;

namespace BSGod.Hacks
{
    public class RecoilHackModule : BaseHackModule
    {
        private BsGodPlayerManager _playerManager;

        public RecoilHackModule(BsGodPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public override void Execute()
        {
            var myPlayer = _playerManager.localPlayer;

            if (myPlayer != null)
            {
                var weapon = myPlayer.source.weaponGraphic;
                if(weapon != null)
                {
                    weapon.Reset();
                }
            }
        }
    }
}
