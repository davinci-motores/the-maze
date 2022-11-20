using UnityEngine;

public abstract class EnemiesStates : MonoBehaviour
{
    public virtual void Enter()
    {
        Debug.Log("Enter");
    }
    public virtual void UpdateState()
    {
        Debug.Log("UpdateState");
    }
    public virtual void Exit()
    {
        Debug.Log("Exit");
    }
}
