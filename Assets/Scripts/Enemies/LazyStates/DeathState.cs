namespace Game.Enemies.LazyStates
{
    public class DeathState : EnemyState
    {
        public override void Enter()
        {
            
        }

        public override EnemyState UpdateState()
        {
            return this;
        }

        public override void Exit()
        {
            
        }
    }
}