﻿using System;
using UnityEngine;

namespace Game.Enemies
{
    public class SpeedyStateManager: StateManager //TPFinal - *Federico Cruz*
    {
        [SerializeField] private EnemyState OnKillState;
        [SerializeField] private EnemyState OnReviveState;
        public Action onDeath;

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