using UnityEngine;
using System;



namespace Game.Enemies
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] protected Enemy enemy;
        [SerializeField] protected EventSO eventSO;

        protected abstract void EventHandler();

        public abstract void Enter();

        public abstract EnemyState UpdateState();

        public abstract void Exit();
		private void OnEnable()
		{
            eventSO.RegisterListener(EventHandler);
		}
		private void OnDisable()
		{
            eventSO.UnregisterListener(EventHandler);
		}
	}
}