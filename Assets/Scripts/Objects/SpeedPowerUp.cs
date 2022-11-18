
namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        protected override void Activate()
        {
            Player.DoubleSpeedBy(seconds);
            //feedback de activacion
        }
    }
}