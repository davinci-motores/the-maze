using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
    public class AttackState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private NormalState _normalState;
        public override void Enter()
        {
            
        }

        public override EnemyState UpdateState()
        {
            if (_rangeOfView.IsTargetInView)
            {
                return _normalState;
            }

            return null;
        }

        public override void Exit()
        {
            
        }
    }
}