using UnityEngine;
using Game.Player;
using Game.SavingSystem;
using System.Collections.Generic;
using System.IO;
using Utils;
using Game.ScriptableObjects;
using Newtonsoft.Json;
using Game.Enemies;

namespace Game.Managers
{
	public class  LoadManager: MonoBehaviour //TPFinal - * Federico Krug *.
	{
		public enum EnemyType
		{
			Speedy,
			Lazy,
			Boss
		}

		[SerializeField] private PlayerController _playerRef;
		[SerializeField] private FloatSO _healthRef;
		public static string GameSaveFileName { get; }  = "/game.json";

		public static bool GameSavedFileExists()
		{
			return File.Exists(Application.persistentDataPath + GameSaveFileName);
		}

		public static LevelData GetGameSavedFile()
		{
			var gameSaveContentFile = File.ReadAllText(Application.persistentDataPath + GameSaveFileName);
			return JsonConvert.DeserializeObject<LevelData>(gameSaveContentFile);
		}

		[ContextMenu("Save Game")]
		public void SaveGame()
		{
			var levelData = new LevelData();
			var transformPosition = _playerRef.transform.position;
			levelData.player.position = new PositionData(
				transformPosition.x,
				transformPosition.y,
				transformPosition.z
				);
			levelData.player.keychain = new List<ColorEnum>(_playerRef.Keychain);
			levelData.player.health = _healthRef.Value;

			levelData.enemies = new Dictionary<string, PositionData>();
			var speedies = GameObject.FindObjectsOfType<SpeedyGomezEnemy>();

			foreach (var speedy in speedies)
			{
				var position = speedy.transform.position;
				levelData.enemies.Add(
					EnemyType.Speedy.ToString()+speedy.Color.ToString(),
					new PositionData(position.x, position.y, position.z)
					);
			}

			var lazy = GameObject.FindObjectOfType<LazyEnemy>().transform.position;
			var boss = GameObject.FindObjectOfType<BossEnemy>().transform.position;

			levelData.enemies.Add(EnemyType.Lazy.ToString(), new PositionData(lazy.x, lazy.y, lazy.z));
			levelData.enemies.Add(EnemyType.Boss.ToString(), new PositionData(boss.x, boss.y, boss.z));


			var jSonString = JsonConvert.SerializeObject(levelData);
			File.WriteAllText(Application.persistentDataPath + GameSaveFileName, jSonString);
		}
	}

}