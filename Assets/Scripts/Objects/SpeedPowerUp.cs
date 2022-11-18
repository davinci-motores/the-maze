
namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        protected override void Activation()
        {
            Player.DoubleSpeedBy(seconds);
            //feedback de activacion
        }
    }
}