using Game.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies.BossState
{
	public class OpenDoorState : EnemyState
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private float _timeToOpenTheDoor;
		[SerializeField] private OpenDoorComponent _openDoorComponent;
		[SerializeField] private bool _alreadyTried = false;
		[SerializeField] private DanceState _danceState;
		private bool _isTryingToOpen = false;

		public override void Enter()
		{
			enemy.Speed = 0;
		}
		public override EnemyState UpdateState()
		{
			if (_isTryingToOpen) return this;
			if (_alreadyTried) return _chaseState;
			if (playerHealth.Value <= 0) return _danceState;
			StartCoroutine(OpenTheDoor());
			return this;
		}
		public override void Exit()
		{
			_alreadyTried = false;
		}
		IEnumerator OpenTheDoor()
		{
			_isTryingToOpen = true;
			yield return new WaitForSeconds(_timeToOpenTheDoor);
			_openDoorComponent.Open();
			_isTryingToOpen = false;
			_alreadyTried = true;
		}
	}

}
