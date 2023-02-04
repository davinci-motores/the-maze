using Game.Managers;
using Game.SavingSystem;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Enemies
{
	public class BossEnemy : Enemy, IDataPersistence
	{
		[SerializeField] private string _attackAnimationParam;
		[SerializeField] private LevelDataEventSO _loadEvent;


		protected override void OnEnableEnemy()
		{
			_loadEvent.RegisterListener(LoadHandler);
		}

		protected override void OnDisableEnemy()
		{
			_loadEvent.UnregisterListener(LoadHandler);
			
		}

		public override void StartAttack()
		{
			animator.SetBool(_attackAnimationParam, true);
		}

		public override void StopAttack()
		{
			animator.SetBool(_attackAnimationParam, false);
		}

		public void LoadHandler(LevelData levelData)
		{
			var positionData = levelData.enemies[LoadManager.EnemyType.Boss.ToString()][0];
			transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
		}
	}
}