using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies.SpeedyStates
{
	public class ChaseState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private NormalState _normalState;
		[SerializeField] private AttackState _attackState;
		[SerializeField] private NavMeshAgent _agent;
		[SerializeField] private float _speed = 10f;
		private Vector3 _enemyView;

		public override void Enter()
		{
			enemy.Speed = _speed;
		}

		public override void Exit()
		{
		}

		public override EnemyState UpdateState()
		{
			if (!_rangeOfView.IsTargetInView)
			{
				return _normalState;
			}

			if (_agent.remainingDistance <= 2)
			{
				return _attackState;
			}
			
			enemy.Move(_rangeOfView.Target.position);
			return this;
		}
		
	}
}

