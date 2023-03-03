using UnityEngine;
using Game.ScriptableObjects;

namespace Game.Enemies
{
    public abstract class EnemyState : MonoBehaviour //TPFinal -  Matias Diaz 
    {
        [SerializeField] protected Enemy enemy;
        [SerializeField] protected FloatEventSO playerHealth;
        protected bool playerIsDead = false;

        protected virtual void OnEnable()
        {
            playerHealth.RegisterListener(UpdatePlayerIsDead);
        }

        private void UpdatePlayerIsDead(float obj)
        {
            if (obj > 0) return;
            playerIsDead = true;
        }

        private void OnDisable()
        {
            playerHealth.UnregisterListener(UpdatePlayerIsDead);
        }

        public abstract void Enter();

        public abstract EnemyState UpdateState();

        public abstract void Exit();
	}
}