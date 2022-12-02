using UnityEngine;

namespace Game.Enemies
{

	public class LazyEnemy : Enemy
	{
		[SerializeField] private string _attackAnimationParam;
		public override void StartAttack()
		{
			animator.SetBool(_attackAnimationParam,true);
		}

		public override void StopAttack()
		{
			animator.SetBool(_attackAnimationParam, false);
		}
	}
}
