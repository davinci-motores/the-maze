using UnityEngine;



namespace Game.Objects
{
    public abstract class PowerUp : MonoBehaviour
    {
		protected GameObject player;
		protected float seconds;
        protected abstract void Activate();
        protected virtual void Destroy()
		{
			Destroy(this.gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				Activate();
				Destroy(); 
			}
		}
		
	}

    
}
