using UnityEngine;
using System;



namespace Game.Enemies
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] protected Enemy enemy;

        public abstract void Enter();

        public abstract EnemyState UpdateState();

        public abstract void Exit();
	}
}