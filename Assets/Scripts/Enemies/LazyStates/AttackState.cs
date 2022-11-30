using UnityEngine;

namespace Game.Enemies.LazyStates
{
    public class AttackState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private NormalState _normalState;
        [SerializeField] private DeathState _deathState;

        public override void Enter()
        {
            enemy.Speed = 0;
        }

        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            if (!_rangeOfView.IsTargetInView)
            {
                return _normalState;
            }
            Debug.Log("Atacando");
            return this;
        }

        public override void Exit()
        {
        }
    }
}
