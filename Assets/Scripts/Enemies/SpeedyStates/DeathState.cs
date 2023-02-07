namespace Game.Enemies.SpeedyStates
{
	public class DeathState : EnemyState
	{
		public override void Enter()
		{
			enemy.IsAlive = false;
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
