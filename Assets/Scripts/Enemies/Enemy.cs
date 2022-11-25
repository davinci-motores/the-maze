using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        private bool _isAlive = true;
        protected float damage = 1f;
        protected float speed = 20;
        public abstract void Attack();

        public virtual void Move(Vector3 position)
        {
            _agent.Move(position);
        }
    }
}