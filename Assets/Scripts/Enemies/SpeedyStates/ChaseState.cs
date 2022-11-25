using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
	public class ChaseState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private Enemy _enemyRef;
		private Vector3 _enemyView;
		private float _speed;

		
		private void Update()
		{
			transform.position += _rangeOfView.Target.position * _speed * Time.deltaTime;
		}

		public override void Enter()
		{
			_enemyView = _rangeOfView.transform.position;
			_enemyView.y = transform.position.y;
			transform.LookAt(_enemyView);
			_speed = _enemyRef.Speed;
			
		}


		public override void Exit()
		{
			
		}

		public override EnemyState UpdateState()
		{

			return this;

		}
	}
}

