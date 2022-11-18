using UnityEngine;
using Game.Player;


namespace Game.Objects
{
    public abstract class PowerUp : MonoBehaviour
    {
		protected GameObject player;
		protected float seconds;
        public abstract void Activate(PlayerController player);
        public abstract void Desactivate(PlayerController player);
        protected virtual void Destroy()
		{
			Destroy(this.gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player")
			{
				other.GetComponent<PlayerController>().ActiveEffect(Activate, Desactivate);
				Destroy(); 
			}
		}
		
	}

    
}
