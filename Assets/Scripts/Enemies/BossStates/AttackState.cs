using Game.ScriptableObjects;

using System;

using UnityEngine;

namespace Game.Enemies.BossState
{
    //TPFinal - Gabriel Rodriguez.
    public class AttackState : EnemyState
    {
        [SerializeField] private ChaseState _chaseState;
        [SerializeField] private float _distance;
        [SerializeField] private DanceState _danceState;
        [SerializeField] private NormalState _normalState;
        [SerializeField] private EventSO _wonEvent;
        private bool _playerWon = false;
        private Transform _target;

        private void Start()
        {
            _target = enemy.Target.transform;
        }

        public override void Enter()
        {
            enemy.Speed = 0;
            enemy.StartAttack();
            _wonEvent.RegisterListener(ToNormal);
        }

		private void ToNormal()
		{
            _playerWon = true;
		}

		public override EnemyState UpdateState()
        {
            if (playerIsDead) return _danceState;
            if (_playerWon) return _normalState;
            if (Vector3.Distance(_target.position, transform.position) > _distance)
            {
                return _chaseState;
            }
            return this;
        }

        public override void Exit()
        {
            enemy.StopAttack();
            _wonEvent.UnregisterListener(ToNormal);
        }
    }
}
