using UnityEngine;

namespace Game.Enemies
{
    public class BossStateManager : StateManager
    {
        [SerializeField] private EnemyState OnActiveState;

        public void Activate()
        {
            ChangeState(OnActiveState);
        }
    }
}