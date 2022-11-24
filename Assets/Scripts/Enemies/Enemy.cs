using UnityEngine;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private bool _isAlive = true;
        protected float damage = 1f;
        protected EnemyState currentState;

        private void Update()
        {
            currentState.UpdateState();
        }

        public void ChangeState(EnemyState nextState)
        {
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }

        public abstract void Attack();
        public abstract void Move();
    }
}