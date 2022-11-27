using UnityEngine;

namespace Game.Enemies.LazyStates
{
	public class NormalState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private float _speed = 10f;
		[SerializeField] private EnemyState _attackState;
		[SerializeField] private EnemyState _openDoorState;
		[SerializeField] private EnemyState _deathState;
		private GameObject _target;
		private bool _isCloseToDoor;

		public bool IsCloseToDoor { get => _isCloseToDoor; set => _isCloseToDoor = value; }

		private void Awake()
		{
			_target = GameObject.FindGameObjectWithTag("Player");
		}

		public override void Enter()
		{
			enemy.Speed = _speed;
		}

		public override void Exit()
		{
			_isCloseToDoor = false;
		}
		public override EnemyState UpdateState()
		{	
			if (!enemy.IsAlive) return _deathState;
			enemy.Move(_target.transform.position);
			if (_rangeOfView.IsTargetInView)
			{
				//ataca
				return _attackState;
			}
			if (IsCloseToDoor)
			{
				return _openDoorState;
			}
			return this;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag ("Door"))
			{
				IsCloseToDoor = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Door"))
			{
				IsCloseToDoor = false;
			}
		}
	}
	
}
