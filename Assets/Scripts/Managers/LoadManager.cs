using UnityEngine;
using Game.Player;
using Game.SavingSystem;
using System.Collections.Generic;
using System.IO;
using Utils;
using Game.ScriptableObjects;
using Game.Objects.Interactables;
using Newtonsoft.Json;

namespace Game.Managers
{
	public class LoadManager : MonoBehaviour
	{
		[SerializeField] private PlayerController _playerRef;
		[SerializeField] private FloatSO _healthRef;
		const string _gameSaveFileName = "/game.json";
		[ContextMenu("Load Game")]
		public void LoadGame()
		{
			if (File.Exists(Application.persistentDataPath + _gameSaveFileName))
			{
				var gameSaveContentFile = File.ReadAllText(Application.persistentDataPath + _gameSaveFileName);
				var levelData = JsonConvert.DeserializeObject<LevelData>(gameSaveContentFile);
				var vectorLevelData = new Vector3(levelData.player.position.x, levelData.player.position.y, levelData.player.position.z);
				_playerRef.transform.position = vectorLevelData;
				_healthRef.Value = levelData.player.health;
				_playerRef.Keychain = new List<ColorEnum>(levelData.player.keychain);

			}
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
			speedyEnemies.Add(new PositionData(0f, 0f, 0f));
			levelData.enemies.Add("Speedy", speedyEnemies);

			var jSonString = JsonConvert.SerializeObject(levelData);
			Debug.Log(Application.persistentDataPath + _gameSaveFileName);
			File.WriteAllText(Application.persistentDataPath + _gameSaveFileName, jSonString);
		}
	}

}