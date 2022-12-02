using Game.Player;
using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
    public class AttackState : EnemyState
    {
        [SerializeField] private DeathState _deathState;
        [SerializeField] private DanceState _danceState;
        [SerializeField] private float _damage = 1f;
        private float _attackRadius = 1f;
        private LayerMask _attackLayer;

        public override void Enter()
        {
        }

        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            if (playerHealth.Value <= 0) return _danceState;
            var colliders = Physics.OverlapSphere(enemy.transform.position, _attackRadius, _attackLayer);
            if (colliders.Length != 0)
            {
                colliders[0].GetComponent<IDamageable>()?.TakeDamage(_damage);
            }

            return _deathState;
        }

        public override void Exit()
        {
            
        }
	}
}