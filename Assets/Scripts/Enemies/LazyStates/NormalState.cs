using Game.Components;
using UnityEngine;

namespace Game.Enemies.LazyStates
{
	public class NormalState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private float _speed = 10f;
		[SerializeField] private EnemyState _attackState;
		[SerializeField] private OpenDoorState _openDoorState;
		[SerializeField] private DeathState _deathState;
		[SerializeField] private OpenDoorComponent _openDoorComponent;
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
			_openDoorComponent.OnDoorDetected += DoorDetectedHandler;
		}

		public override void Exit()
		{
			_isCloseToDoor = false;
			_openDoorComponent.OnDoorDetected -= DoorDetectedHandler;
		}

		public override EnemyState UpdateState()
		{	
			if (!enemy.IsAlive) return _deathState;
			enemy.Move(_target.transform.position);
			if (_rangeOfView.IsTargetInView)
			{
				return _attackState;
			}
			if (IsCloseToDoor)
			{
				return _openDoorState;
			}
			return this;
		}

		private void DoorDetectedHandler()
		{
			IsCloseToDoor = true;
		}
	}
	
}
