using Game.Enemies;
using UnityEngine;

public class OpenDoorState : EnemyState
{
    public override void Enter()
    {
        Debug.Log("Enter OpenDoor");
    }
    public override void UpdateState()
    {
        Debug.Log("UpdateState OpenDoor");
        return this;
    }
    public override void Exit()
    {
        Debug.Log("Exit OpenDoor");
    }
}
