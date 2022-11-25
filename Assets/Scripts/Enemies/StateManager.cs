using UnityEngine;

namespace Game.Enemies
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] EnemyState currentState;
        private void Update()
        {
            var nextState = currentState?.UpdateState();

            if (nextState != null)
            {
                ChangeState(nextState);
            }
        }
        
        public void ChangeState(EnemyState nextState)
        {
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
    }
}