using Game.Player.Camera;
using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
    public class AttackState : EnemyState
    {
        [SerializeField] private DeathState _deathState;
        [SerializeField] private float _damage = 1f;
        private float _attackRadius = 1f;
        private LayerMask _attackLayer;

        public override void Enter()
        {
        }

        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
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