using Game.Player;

namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        protected override void Activate()
        {
            player.GetComponent<PlayerController>()?.DoubleSpeedBy(seconds);
            //feedback de activacion
        }
    }
}