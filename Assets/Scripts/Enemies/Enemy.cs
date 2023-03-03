using Game.SavingSystem;
using Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    //TPFinal - Gabriel Rodriguez.
    public abstract class Enemy : MonoBehaviour, IDataPersistence
    {
        [SerializeField] protected NavMeshAgent _agent;
        [SerializeField] private EventSO _deathEvent;
        [SerializeField] protected Animator animator;
        [SerializeField] private string _danceAnimationParam;
        [SerializeField] protected LevelDataEventSO _loadEvent;
        private GameObject _target;

        private float speed = 20;
        public bool IsAlive { get; set; } = true;
        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnEnable()
        {
            _deathEvent.RegisterListener(DeathHandler);
            _loadEvent.RegisterListener(LoadHandler);

            OnEnableEnemy();
        }

        protected abstract void OnEnableEnemy();

        private void OnDisable()
        {
            _deathEvent.UnregisterListener(DeathHandler);
            _loadEvent.UnregisterListener(LoadHandler);
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

        public abstract void LoadHandler(LevelData levelData);
    }
}