using UnityEngine;
using Game.Player;



namespace Game.Objects
{
	public  class InvenciblePowerUp : PowerUp
	{

		public override void Activate(PlayerController player)
		{
			Debug.Log("Invencible");
		}
		public override void Desactivate(PlayerController player)
		{
			Debug.Log("Default - Weak");
		}
	}

	
}

