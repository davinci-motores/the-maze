using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Enemies.BossState
{
    public class NormalState : EnemyState
    {
        [SerializeField] private EventSO _activeEvent;
        private bool _isActive = false;
        private ChaseState _chaseState;

        public override void Enter()
        {
            enemy.StopMove();
            _activeEvent.RegisterListener(ActiveHandler);
        }

        private void ActiveHandler()
        {
            _isActive = true;
        }

        public override EnemyState UpdateState()
        {
            if (_isActive)
            {
                return _chaseState;
            }

            return this;
        }

        public override void Exit()
        {
            _activeEvent.UnregisterListener(ActiveHandler);
        }
    }
}