using UnityEngine;
using System.Collections;
using Game.Components;
using UnityEngine.AI;

namespace Game.Enemies.LazyStates 
{
    public class OpenDoorState : EnemyState
    {
        [SerializeField] private NormalState _normalState;
        [SerializeField] private float _timeToOpenTheDoor;
        [SerializeField] private EnemyState _deathState;
        [SerializeField] private OpenDoorComponent _openDoorComponent;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private bool _alreadyTried = false;
        [SerializeField] private DanceState _danceState;
        private bool _isTryingToOpen = false;

        public override void Enter()
        {
            _agent.speed = 0;
        }
        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            if (_isTryingToOpen) return this;
            if (_alreadyTried) return _normalState;
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

