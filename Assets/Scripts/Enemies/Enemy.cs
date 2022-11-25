using UnityEngine;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private bool _isAlive = true;
        protected float damage = 1f;
        public abstract void Attack();
        public abstract void Move();
    }
}