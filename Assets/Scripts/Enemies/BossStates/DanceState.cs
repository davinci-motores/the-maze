using System.Collections;
using System.Collections.Generic;
using Game.Enemies;
using UnityEngine;

namespace Game.Enemies.BossState
{
    public class DanceState : EnemyState
    {
        public override void Enter()
        {
            enemy.Dance();
        }

        public override EnemyState UpdateState()
        {
            return this;
        }

        public override void Exit()
        {
           
        }
    }
}

