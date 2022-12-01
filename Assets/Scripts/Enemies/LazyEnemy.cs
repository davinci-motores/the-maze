using UnityEngine;

namespace Game.Enemies
{

	public class LazyEnemy : Enemy
	{
		[SerializeField] private string _animationParam;
		public override void StartAttack()
		{
			Debug.Log($"StartAttack animationParam: {_animationParam} is true");
			animator.SetBool(_animationParam,true);
		}

		public override void StopAttack()
		{
			Debug.Log($"StopAttack animationParam: {_animationParam} is false");
			animator.SetBool(_animationParam, false);
		}
	}
}
