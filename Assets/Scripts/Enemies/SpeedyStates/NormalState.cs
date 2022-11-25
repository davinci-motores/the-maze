using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Game.Enemies.SpeedyStates
{
    public class NormalState : EnemyState
    {
        [SerializeField] private RangeOfView _rangeOfView;
        [SerializeField] private AttackState _attackState;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [SerializeField] private List<Transform> wayPoint = new List<Transform>();
        private int wpList;
        private int _direction;


        public override void Enter()
        {
            wpList = 0;
            _direction = 1;
            enemy.Move(wayPoint[wpList].position);
        }

        public override EnemyState UpdateState()
        {
            if (_rangeOfView.IsTargetInView)
            {
                return _attackState;
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
              Debug.Log($"wpList , {wpList}");
                if (wpList >= wayPoint.Count || wpList <= 0)
                {
                    Debug.Log(("a"));
                    _direction *= -1;
                }

                enemy.Move(wayPoint[wpList].position);
            }
        }
    }
}