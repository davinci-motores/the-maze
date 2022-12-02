using System;
using UnityEngine;

namespace Game.Enemies.LazyStates
{
    public class AttackState : EnemyState
    {
        [SerializeField] private NormalState _normalState;
        [SerializeField] private DeathState _deathState;
        [SerializeField]private float _distance;
        [SerializeField] private DanceState _danceState;
        private Transform _target;

        private void Start()
        {
            _target = enemy.Target.transform;
        }

        public override void Enter()
        {
            enemy.Speed = 0;
            enemy.StartAttack();
        }

        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            if (playerIsDead) return _danceState;
            if (Vector3.Distance(_target.position, transform.position) > _distance)
            {
                return _normalState;
            }
            
           
            return this;
        }

        public override void Exit()
        {
            enemy.StopAttack();
           
        }
    }
}
