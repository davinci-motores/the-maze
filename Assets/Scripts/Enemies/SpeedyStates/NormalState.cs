using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
    public class NormalState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private AttackState _attackState;

        public override void Enter()
        {
            
        }

        public override EnemyState UpdateState()
        {
            if (_rangeOfView.IsTargetInView)
            {
                return _attackState;
            }

            return null;

        }

        public override void Exit()
        {
        }
    }
}