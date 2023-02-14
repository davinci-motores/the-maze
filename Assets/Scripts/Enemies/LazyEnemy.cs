using Game.Managers;
using Game.SavingSystem;
using UnityEngine;

namespace Game.Enemies
{

	public class LazyEnemy : Enemy //TPFinal - * Federico Krug *.
	{
		[SerializeField] private string _attackAnimationParam;

		protected override void OnEnableEnemy()
		{
		}

		protected override void OnDisableEnemy()
		{
		}

		public override void StartAttack()
		{
			animator.SetBool(_attackAnimationParam,true);
		}

		public override void StopAttack()
		{
			animator.SetBool(_attackAnimationParam, false);
		}

		public override void LoadHandler(LevelData levelData)
		{
			_agent.enabled = false;
			var positionData = levelData.enemies[LoadManager.EnemyType.Lazy.ToString()];
			transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			_agent.enabled = true;
		}
	}
}
