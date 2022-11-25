using UnityEngine;

namespace Game.Enemies.SpeedyStates {
	public class RangeOfView : MonoBehaviour
	{
		private bool _isTargetInView = false;
		[SerializeField] private Transform _target;

		private void Awake()
		{
			_target = GameObject.FindGameObjectWithTag("Player").transform;
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
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				IsTargetInView = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				IsTargetInView = false;
			}
		}
	}
}