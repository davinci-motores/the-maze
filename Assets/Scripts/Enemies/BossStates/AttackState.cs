using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

namespace Game.Enemies.BossState
{
    public class AttackState : EnemyState
    {
        [SerializeField] private ChaseState _chaseState;
        [SerializeField] private float _distance;
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
            if (playerHealth.Value <= 0) return _danceState;
            if (Vector3.Distance(_target.position, transform.position) > _distance)
            {
                return _chaseState;
            }


            return this;
        }

        public override void Exit()
        {
            enemy.StopAttack();
        }
    }
}
