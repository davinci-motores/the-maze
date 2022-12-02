using UnityEngine;
using Game.ScriptableObjects;


namespace Game.Enemies
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] protected Enemy enemy;
        [SerializeField] protected FloatSO playerHealth;

        public abstract void Enter();

        public abstract EnemyState UpdateState();

        public abstract void Exit();
	}
}