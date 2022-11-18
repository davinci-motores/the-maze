using UnityEngine;



namespace Game.Objects
{
    public abstract class PowerUp : MonoBehaviour
    {
        public abstract void Activate();
        public abstract void Destroy();
    }
}
