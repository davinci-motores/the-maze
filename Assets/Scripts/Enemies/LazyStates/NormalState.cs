using UnityEngine;

using UnityEngine.AI;



namespace Game.Enemies.LazyStates
{
	public class NormalState : EnemyState
	{
		[SerializeField] private RangeOfView _rangeOfView;
		private GameObject _target;
		private bool _isCloseToDoor;
		[SerializeField] private NavMeshAgent _agent;
		[SerializeField] private float _speed = 10f;
		[SerializeField] private EnemyState _attackState;
		[SerializeField] private EnemyState _openDoorState;

		public bool IsCloseToDoor { get => _isCloseToDoor; set => _isCloseToDoor = value; }

		public override void Enter()
		{
			enemy.Speed = _speed;
		}

		//public bool EnemyIsCloseToDoor
		//{
		//	get => _isCloseToDoor; set => _isCloseToDoor = value;
		//}

		public override void Exit()
		{
			_isCloseToDoor = false;
		}

		private void Awake()
		{
			_target = GameObject.FindGameObjectWithTag("Player");
		}
		public override EnemyState UpdateState()
		{	
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
