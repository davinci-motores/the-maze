using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemies.SpeedyStates
{
    public class NormalState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private ChaseState _chaseState;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float speed = 3.5f;
        [SerializeField] private List<Transform> wayPoint = new List<Transform>();
        private int wpList = 0;
        private int _direction = 1;


        public override void Enter()
        {
            enemy.Speed = speed;
            wpList = 0;
            _direction = 1;
            enemy.Move(wayPoint[wpList].position);
        }

        public override EnemyState UpdateState()
        {
            if (_rangeOfView.IsTargetInView)
            {
                return _chaseState;
            }

            Patrol();

            return null;
        }

        public override void Exit()
        {
        }

        private void Patrol()
        {
            if (_navMeshAgent.remainingDistance <= 2)
            {
                wpList += _direction;
                if (wpList >= wayPoint.Count - 1 || wpList <= 0)
                {
                    _direction *= -1;
                }

                enemy.Move(wayPoint[wpList].position);
            }
        }
    }
}