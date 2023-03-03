namespace Game.Enemies
{
    public class DanceState : EnemyState //TPFinal - * Federico Krug *.
    {
        public override void Enter()
        {
            enemy.StopMove();
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