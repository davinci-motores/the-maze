﻿using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        protected float speed = 20;

        public virtual void Move(Vector3 position)
        {
            _agent.SetDestination(position);
        }

        public float Speed
        {
            get => speed;
            set
            {
                speed = value;
                _agent.speed = speed;
            }
        }
    }
}