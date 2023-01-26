using Game.Components;
using UnityEngine;

namespace Game.Enemies.BossState
{
    public class ChaseState : EnemyState
    {
		[Header("States")]
		[SerializeField] private AttackState _attackState;
		[SerializeField] private OpenDoorState _openDoorState;
		
		[SerializeField] private DanceState _danceState;
		[Header("Dependencies")]
		[SerializeField] private OpenDoorComponent _openDoorComponent;
		[Header("Config")]
		[SerializeField] private float _speed = 10f;
		[SerializeField] private float _distance;

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
			
			if (playerIsDead) return _danceState;
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
