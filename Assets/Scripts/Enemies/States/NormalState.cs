using UnityEngine;
using Game.Enemies;

public class NormalState : EnemyState
{
    public override void Enter()
    {
        Debug.Log("Enter Normal");
    }
    public override EnemyState UpdateState()
    {
        Debug.Log("UpdateState Normal");
        return this;
    }
    public override void Exit()
    {
        Debug.Log("Exit Normal");
    }
}
