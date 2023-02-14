using UnityEngine;

namespace Game.Enemies {
	public class RangeOfView : MonoBehaviour //TPFinal - * Federico Krug *.
	{
		private bool _isTargetInView = false;
		[SerializeField] private Transform _target;
		private bool _isTargetInRange = false;
		[SerializeField] private Transform _eyes;
		private Ray _ray;
		[SerializeField] private LayerMask _obstacleLayer;
		private RaycastHit _hitInfo;

		private void Awake()
		{
			_ray = new Ray();
		}

		private void Update()
		{
			if (_isTargetInRange)
			{
				IsTargetInView = !HaveAnObstacleBetween();
			}
		}

		public bool IsTargetInView
		{
			get => _isTargetInView;
			private set => _isTargetInView = value;
		}
		public Transform Target
		{
			get => _target; set => _target = value;
		}

		private bool HaveAnObstacleBetween()
		{
			var position = _eyes.position;
			_ray.origin = position;
			_ray.direction = _target.position - position;
			if (Physics.Raycast(_ray, out _hitInfo, 100f, _obstacleLayer))
			{
				if (_hitInfo.collider.gameObject != Target.gameObject)
				{
					return true;
				}
			}
			return false;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_isTargetInRange = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_isTargetInRange = false;
				IsTargetInView = false;
			}
		}
	}
}