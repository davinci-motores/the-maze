using Game.Components;
using UnityEngine;

namespace Game.Enemies.LazyStates
{
	public class NormalState : EnemyState
	{
		[SerializeField] private float _speed = 10f;
		[SerializeField] private AttackState _attackState;
		[SerializeField] private OpenDoorState _openDoorState;
		[SerializeField] private DeathState _deathState;
		[SerializeField] private OpenDoorComponent _openDoorComponent;
		[SerializeField]private float _distance;
		
		private bool _isCloseToDoor;
		private Transform _target;

		public bool IsCloseToDoor { get => _isCloseToDoor; set => _isCloseToDoor = value; }

		private void Start()
		{
			_target = enemy.Target.transform;
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
			enemy.Move(enemy.Target.transform.position);
			if (Vector3.Distance(_target.position, transform.position) <= _distance)
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
