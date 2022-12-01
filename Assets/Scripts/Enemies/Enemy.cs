using Game.ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EventSO _deathEvent;
        [SerializeField] protected Animator animator;

        protected float speed = 20;
        public bool IsAlive { get; private set; } = true;

        private void OnEnable()
        {
            _deathEvent.RegisterListener(DeathHandler);
        }

        private void OnDisable()
        {
            _deathEvent.UnregisterListener(DeathHandler);
        }

        public virtual void Move(Vector3 position)
        {
            _agent.SetDestination(position);
        }

        public float Speed
        {
            get => speed;
            set
            {
                speed = value;
                _agent.speed = speed;
            }
        }

        public float RemainingDistance => _agent.remainingDistance;

        private void DeathHandler()
        {
            IsAlive = false;
        }

        public abstract void StartAttack();
        public abstract void StopAttack();
    }
}