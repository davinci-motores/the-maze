using UnityEngine;

namespace Game.Enemies.SpeedyStates
{
	public class DeathState : EnemyState //TPFinal - * Federico Krug *.
	{
		[SerializeField] private SpeedyStateManager _speedySM;

		public override void Enter()
		{
			enemy.IsAlive = false;
			_speedySM.onDeath.Invoke();
			gameObject.SetActive(false);
		}

		public override void Exit()
		{
		}

		public override EnemyState UpdateState()
		{
			return this;
		}
	}
}
