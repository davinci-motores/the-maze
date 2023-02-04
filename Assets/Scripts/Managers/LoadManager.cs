using UnityEngine;
using Game.Player;
using Game.SavingSystem;
using System.Collections.Generic;
using System.IO;
using Utils;
using Game.ScriptableObjects;
using Game.Objects.Interactables;
using Newtonsoft.Json;
using Game.Enemies;

namespace Game.Managers
{
	public class  LoadManager: MonoBehaviour
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
		[ContextMenu("Load Game")]
		public void LoadGame()
		{
			if (!GameSavedFileExists()) return;

			GetGameSavedFile();
			// var vectorLevelData = new Vector3(levelData.player.position.x, levelData.player.position.y, levelData.player.position.z);
			// _playerRef.transform.position = vectorLevelData;
			// _healthRef.Value = levelData.player.health;
			// _playerRef.Keychain = new List<ColorEnum>(levelData.player.keychain);
			//
			//
			// var speedies = GameObject.FindObjectsOfType<SpeedyGomezEnemy>();
			//
			// for (int i = 0; i < speedies.Length; i++)
			// {
			// 	var positionData = levelData.enemies[EnemyType.Speedy.ToString()][i];
			// 	speedies[i].transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			// }
			//
			// var lazy = GameObject.FindObjectOfType<LazyEnemy>();
			// if (lazy != null)
			// {
			// 	var positionData = levelData.enemies[EnemyType.Lazy.ToString()][0];
			// 	lazy.transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			// }
			// var boss = GameObject.FindObjectOfType<BossEnemy>();
			// if (boss != null)
			// {
			// 	var positionData = levelData.enemies[EnemyType.Boss.ToString()][0];
			// 	boss.transform.position = new Vector3(positionData.x, positionData.y, positionData.z);
			// }
			// Debug.Log("Load Game !!");
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

			levelData.enemies = new Dictionary<string, List<PositionData>>();
			var speedyEnemies = new List<PositionData>();
			var speedies = GameObject.FindObjectsOfType<SpeedyGomezEnemy>();

			foreach (var speedy in speedies)
			{
				var position = speedy.transform.position;
				speedyEnemies.Add(new PositionData(position.x, position.y, position.z));

			}
			levelData.enemies.Add(EnemyType.Speedy.ToString(), speedyEnemies);

			var lazy = GameObject.FindObjectOfType<LazyEnemy>().transform.position;
			Debug.Log(lazy.x+ " " +lazy.y+ " " +lazy.z);
			var boss = GameObject.FindObjectOfType<BossEnemy>().transform.position;

			levelData.enemies.Add(EnemyType.Lazy.ToString(), new List<PositionData>() {new PositionData(lazy.x, lazy.y, lazy.z) });
			levelData.enemies.Add(EnemyType.Boss.ToString(), new List<PositionData>() {new PositionData(boss.x, boss.y, boss.z) });


			var jSonString = JsonConvert.SerializeObject(levelData);
			File.WriteAllText(Application.persistentDataPath + GameSaveFileName, jSonString);
		}
	}

}