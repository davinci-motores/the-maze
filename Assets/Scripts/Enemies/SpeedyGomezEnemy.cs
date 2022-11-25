using UnityEngine;

namespace Game.Enemies
{
	public class SpeedyGomezEnemy : Enemy
	{
		public override void Attack()
		{
			Debug.Log("SpeedyGomez has Attacked");
		}

		public override void Move()
		{
			Debug.Log("SpeedyGomez is moving");
		}


	}
}