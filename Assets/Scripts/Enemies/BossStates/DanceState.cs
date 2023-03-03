namespace Game.Enemies.BossState
{
    public class DanceState : EnemyState //TPFinal - * Federico Krug *.
    {
        public override void Enter()
        {
            enemy.Dance();
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

