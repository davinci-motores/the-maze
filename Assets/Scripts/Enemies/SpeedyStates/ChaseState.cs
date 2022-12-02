using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies.SpeedyStates
{
    public class ChaseState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private NormalState _normalState;
        [SerializeField] private AttackState _attackState;
        [SerializeField] private EnemyState _deathState;
        [SerializeField] private DanceState _danceState;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _distance;

        public override void Enter()
        {
            enemy.Speed = _speed;
        }

        public override void Exit()
        {
        }

        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            if (playerHealth.Value <= 0) return _danceState;
            if (!_rangeOfView.IsTargetInView)
            {
                return _normalState;
            }

            if (enemy.RemainingDistance <= _distance)
            {
                return _attackState;
            }

            enemy.Move(_rangeOfView.Target.position);
            return this;
        }
    }
}