using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Enemies.BossState
{
    public class NormalState : EnemyState
    {
        [SerializeField] private EventSO _activeEvent;
        [SerializeField] private ChaseState _chaseState;
        private bool _isActive = false;

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
            Debug.Log("Sali del NormalState");
        }
    }
}