namespace Game.Enemies.LazyStates
{
    public class DeathState : EnemyState //TPFinal - * Federico Krug *.
    {
        public override void Enter()
        {
            gameObject.SetActive(false);
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