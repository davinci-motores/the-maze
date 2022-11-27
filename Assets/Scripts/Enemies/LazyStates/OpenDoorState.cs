using Game.Enemies;
using UnityEngine;
using System.Collections;
namespace Game.Enemies.LazyStates 
{
    public class OpenDoorState : EnemyState
    {
        [SerializeField] private NormalState _normalState;
        [SerializeField] private float _timeToOpenTheDoor;
        [SerializeField] private EnemyState _deathState;

        public override void Enter()
        {
            Debug.Log("Enter OpenDoor");
        }
        public override EnemyState UpdateState()
        {
            if (!enemy.IsAlive) return _deathState;
            Debug.Log("UpdateState OpenDoor");
            return this;
        }
        public override void Exit()
        {
            Debug.Log("Exit OpenDoor");
        }
        IEnumerator OpenTheDoor()
		{
            yield return new WaitForSeconds(_timeToOpenTheDoor);
        }
	}

}

