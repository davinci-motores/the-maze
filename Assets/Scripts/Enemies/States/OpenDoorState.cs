using UnityEngine;

public class OpenDoorState : EnemiesStates
{
    public override void Enter()
    {
        Debug.Log("Enter OpenDoor");
    }
    public override void UpdateState()
    {
        Debug.Log("UpdateState OpenDoor");
    }
    public override void Exit()
    {
        Debug.Log("Exit OpenDoor");
    }
}
