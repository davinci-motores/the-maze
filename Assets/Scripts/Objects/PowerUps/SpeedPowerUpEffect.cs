using Game.Player;
using UnityEngine;

namespace Game.Objects.PowerUps
{
    public class SpeedPowerUpEffect : PowerUpEffect
    {
        [SerializeField] private float _speedMultiplier = 2f;
        private float _playerSpeedDefault;
        private PlayerController player;

        protected override void Activate()
        {
            player = gameObject.GetComponentInParent<PlayerController>();
            _playerSpeedDefault = player.Speed;
            player.Speed = _playerSpeedDefault * _speedMultiplier;
            player.IsRunning(true);
            Debug.Log($"{_playerSpeedDefault}, {player.Speed}");
        }
        
        protected override void Desactivate()
        {
            player.Speed = _playerSpeedDefault;
            player.IsRunning(false);
        }
    }
}