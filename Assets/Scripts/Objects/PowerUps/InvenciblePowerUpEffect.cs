using UnityEngine;

namespace Game.Objects.PowerUps
{
	public  class InvenciblePowerUpEffect : PowerUpEffect
	{
		[SerializeField] private int _invencibleLayer = 3;
		private int _playerLayer;
		private GameObject _player;

		protected override void Activate()
		{
			_player = transform.parent.gameObject;
			_playerLayer = _player.layer;
			_player.layer = _invencibleLayer;
		}
		protected override void Desactivate()
		{
			_player.layer = _playerLayer;
		}
	}

	
}

