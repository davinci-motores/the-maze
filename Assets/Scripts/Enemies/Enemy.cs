using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EventSO _deathEvent;
        protected float speed = 20;
        public bool IsAlive { get; private set; } = true;

        [ContextMenu("Raise")]
        public void Prueba()
        {
            _deathEvent.Raise();
        }
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

        private void DeathHandler()
        {
            IsAlive = false;
        }
    }
}