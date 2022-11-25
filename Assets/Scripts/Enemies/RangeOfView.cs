using UnityEngine;

namespace Game.Enemies.SpeedyStates {
	public class RangeOfView : MonoBehaviour
	{
		private bool _isTargetInView;
		[SerializeField] private Transform _target;

		private void Awake()
		{
			_target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		public bool IsTargetInView
		{
			get => _isTargetInView;
			set => _isTargetInView = value;
		}
		public Transform Target
		{
			get => _target; set => _target = value;
		}
		private void Update()
		{
			if (_target)
			{
				_isTargetInView = true;
			}
			else
			{
				_isTargetInView = false;
			}
		}
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				IsTargetInView = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.tag == "Player")
			{
				IsTargetInView = false;
			}
		}
	}
}