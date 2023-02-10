using System;
using Game.Managers;
using Game.SavingSystem;
using UnityEngine;
using Utils;

namespace Game.Enemies
{
	public class SpeedyGomezEnemy : Enemy
	{
		[field: SerializeField]
		public ColorEnum Color { get; set; }

		protected override void OnEnableEnemy()
		{
		}

		protected override void OnDisableEnemy()
		{
		}

		public override void StartAttack()
		{
		}

		public override void StopAttack()
		{
		}

		public override void LoadHandler(LevelData levelData)
		{
			var key = LoadManager.EnemyType.Speedy.ToString()+Color.ToString();
			if (!levelData.enemies.ContainsKey(key)) return;

			_agent.enabled = false;
			var positionData = levelData.enemies[key];
			transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			_agent.enabled = true;
		}
	}
}