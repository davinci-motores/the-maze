using UnityEngine;

namespace Game.Enemies
{
    public class SpeedyStateManager: StateManager
    {
        [SerializeField] private EnemyState OnKillState;
        [SerializeField] private EnemyState OnReviveState;
        public void Kill()
        {
            ChangeState(OnKillState);
        }

        public void Revive()
        {
            ChangeState(OnReviveState);

        }
    }
}