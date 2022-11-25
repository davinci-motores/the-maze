using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Enemies.SpeedyStates {
	public class RangeOfView : MonoBehaviour
	{
		private bool _isTargetInView;
		[SerializeField] private Transform _target;

		private void Awake()
		{
			//_target = GameObject.FindGameObjectsWithTag("Player").;
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