using UnityEngine;

namespace Game.Objects.PowerUps
{
    public class IntangiblePowerUp : PowerUp
    {
        [SerializeField] private int _intangibleLayer = 8;
        private int _playerLayer;
        private GameObject _player;

        protected override void Activate()
        {
            _player = transform.parent.gameObject;
            _playerLayer = _player.layer;
            _player.layer = _intangibleLayer;
        }
        protected override void Desactivate()
        {
            _player.layer = _playerLayer;
        }
    }

}
