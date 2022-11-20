using UnityEngine;
using Game.Player;



namespace Game.Objects
{
	public  class InvenciblePowerUp : PowerUp
	{

		public override void Activate(PlayerController player)
		{
			Debug.Log("Invencible");
			player.gameObject.layer = 3; //camnbio la layer a una que los enemigos pueden tocar pero no dañar
		}
		public override void Desactivate(PlayerController player)
		{
			Debug.Log("Default - Weak");
			player.gameObject.layer = 0; //vuelvo a la layer original
		}
	}

	
}

