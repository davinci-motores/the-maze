using Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected NavMeshAgent _agent;
        [SerializeField] private EventSO _deathEvent;
        [SerializeField] protected Animator animator;
        [SerializeField] private string _danceAnimationParam;
        private GameObject _target;

        private float speed = 20;
        public bool IsAlive { get; private set; } = true;
        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnEnable()
        {
            _deathEvent.RegisterListener(DeathHandler);
            OnEnableEnemy();
        }

        protected abstract void OnEnableEnemy();

        private void OnDisable()
        {
            _deathEvent.UnregisterListener(DeathHandler);
            OnDisableEnemy();
        }

        protected abstract void OnDisableEnemy();

        public void Move(Vector3 position)
        {
            _agent.isStopped = false;
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
        public GameObject Target { get => _target;}

        private void DeathHandler()
        {
            IsAlive = false;
        }

        public abstract void StartAttack();
        public abstract void StopAttack();

        public void Dance()
        {
            animator.SetTrigger(_danceAnimationParam);
        }

        public void StopMove()
        {
            _agent.isStopped = true;
        }
    }
}