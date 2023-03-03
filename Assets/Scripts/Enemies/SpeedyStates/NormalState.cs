using System.Collections.Generic;

using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
	public class NormalState : EnemyState //TPFinal -  Matias Diaz 
	{
		[SerializeField] private RangeOfView _rangeOfView;
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private DeathState _deathState;
		[SerializeField] private DanceState _danceState;
		[SerializeField] private float speed = 3.5f;
		[SerializeField] private List<Transform> wayPoint = new List<Transform>();
		private int wpList = 0;
		private int _direction = 1;

		public List<Transform> WayPoint
		{
			get => wayPoint;
			set
			{
				wayPoint = value;
			}
		}


		private void Start()
		{
			_rangeOfView.Target = enemy.Target.transform;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			enemy.IsAlive = true;
		}

		public override void Enter()
		{
			enemy.Speed = speed;
			wpList = 0;
			_direction = 1;
			enemy.Move(WayPoint[wpList].position);
		}

		public override EnemyState UpdateState()
		{
			if (!enemy.IsAlive) return _deathState;
			if (playerIsDead) return _danceState;
			if (_rangeOfView.IsTargetInView)
			{
				return _chaseState;
			}
			Patrol();

			return this;
		}

		public override void Exit()
		{
		}

		private void Patrol()
		{
			if (enemy.RemainingDistance <= 2)
			{
				wpList += _direction;
				if (wpList >= WayPoint.Count - 1 || wpList <= 0)
				{
					_direction *= -1;
				}

				enemy.Move(WayPoint[wpList].position);
			}
		}
	}
}