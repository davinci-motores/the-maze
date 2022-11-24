using UnityEngine;

namespace Game.Enemies
{

    public class LazyEnemy : Enemy
    {
        public override void Attack()
        {
            Debug.Log("LazyAttack");
        }
        public override void Move()
        {
            Debug.Log("LazyMove");
        }
    }
}
