using UnityEngine;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private bool _isAlive = true;
        protected float damage = 1f;
        protected IState currentState;

        private void Update()
        {
            currentState.UpdateState();
        }

        public void ChangeState(IState nextState)
        {
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }

        public abstract void Attack();
        public abstract void Move();
    }

    public interface IState // temporal mientras no existe State la clase;
    {
        public void Enter();
        public void UpdateState();
        public void Exit();
    }
}