using Game.Player;
using UnityEngine;

namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        [SerializeField] private float _seconds;

        protected override void Activate()
        {
            player.GetComponent<PlayerController>()?.DoubleSpeedBy(_seconds);
            //feedback de activacion
        }
    }
}