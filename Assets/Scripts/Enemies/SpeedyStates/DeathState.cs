namespace Game.Enemies.SpeedyStates
{
	public class DeathState : EnemyState
	{
		public override void Enter()
		{
			gameObject.SetActive(false);
		}

		public override void Exit()
		{
		}

		public override EnemyState UpdateState()
		{
			return this;
		}

		protected override void EventHandler()
		{
			
		}
	}
}
