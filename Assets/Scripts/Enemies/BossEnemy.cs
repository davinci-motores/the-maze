using Game.Managers;
using Game.SavingSystem;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Enemies
{
	public class BossEnemy : Enemy //TPFinal - * Federico Krug *.
	{
		[SerializeField] private string _attackAnimationParam;
		[SerializeField] private BossStateManager _bossStateManager;

		protected override void OnEnableEnemy()
		{
		}

		protected override void OnDisableEnemy()
		{
		}

		public override void StartAttack()
		{
			animator.SetBool(_attackAnimationParam, true);
		}

		public override void StopAttack()
		{
			animator.SetBool(_attackAnimationParam, false);
		}

		public override void LoadHandler(LevelData levelData)
		{
			if (levelData.enemies.Count == 1 && levelData.enemies.ContainsKey(LoadManager.EnemyType.Boss.ToString()))
			{
				_bossStateManager.Activate();
			}
			_agent.enabled = false;
			var positionData = levelData.enemies[LoadManager.EnemyType.Boss.ToString()];
			transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			_agent.enabled = true;
		}
	}
}