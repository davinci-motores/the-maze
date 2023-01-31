using UnityEngine;
using Game.Player;
using Game.SavingSystem;
using System.Collections.Generic;
using System.IO;
using Utils;
using Game.ScriptableObjects;
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
			var colorList = new List<ColorEnum>();
			foreach (var key in _playerRef.Keychain)
			{
				colorList.Add(key.Color);
			}
			levelData.player.keychain = colorList;
			levelData.player.health = _healthRef.Value;

			levelData.enemies = new Dictionary<string, List<PositionData>>();
			var speedyEnemies = new List<PositionData>();
			speedyEnemies.Add(new PositionData(0f, 0f, 0f));
			levelData.enemies.Add("Speedy", speedyEnemies);

			var jSonString = JsonConvert.SerializeObject(levelData);

			File.WriteAllText(Application.persistentDataPath + _gameSaveFileName, jSonString);
		}
	}

}