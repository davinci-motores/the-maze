using Game.Player;
using UnityEngine;

namespace Game.Objects
{
    public class SpeedPowerUp : PowerUp
    {
        [SerializeField, Range(1, 3)] private float _speedMultiplier = 2f;
        private float _playerSpeedDefault; 
        public override void Activate(PlayerController player)
        {
            _playerSpeedDefault = player.Speed;
            player.Speed = _playerSpeedDefault * _speedMultiplier;
        }
        
        public override void Desactivate(PlayerController player)
        {
            player.Speed = _playerSpeedDefault;
        }
    }
}