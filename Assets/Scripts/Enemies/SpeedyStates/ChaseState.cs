using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
	public class ChaseState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private NormalState _normalState;
		private Vector3 _enemyView;
		private float _speed;


		
		public override void Enter()
		{
			Debug.Log("Entro al estado de Chase");
			_enemyView = _rangeOfView.transform.position;
			_enemyView.y = transform.position.y;
			transform.LookAt(_enemyView);
			_speed = enemy.Speed;

		}


		public override void Exit()
		{
			Debug.Log("Salio del estado de Chase");
		}

		public override EnemyState UpdateState()
		{
			Debug.Log("Me mantengo en el estado de Chase"); 
			if (!_rangeOfView.IsTargetInView)
			{
				return _normalState;
		
			}
			
			Debug.Log("Me mantengo en el estado de Chase");
			enemy.Move(_rangeOfView.Target.position);
			return this;

		}
		
	}
}

