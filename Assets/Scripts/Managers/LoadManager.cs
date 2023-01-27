using UnityEngine;
using Game.Player;
using Game.SavingSystem;
using System.Collections.Generic;
using Utils;
using Game.ScriptableObjects;
namespace Game.Managers
{
	public class LoadManager : MonoBehaviour
	{
		[SerializeField] private PlayerController _playerRef;
		[SerializeField] private FloatSO _healthRef;

		public void LoadGame()
		{
			
		}
		[ContextMenu("Save Game")]
		public void SaveGame()
		{
			var levelData = new LevelData();
			levelData.player.position = _playerRef.transform.position;

			var colorList = new List<ColorEnum>();
			foreach (var key in _playerRef.Keychain)
			{
				colorList.Add(key.Color);
			}

			levelData.player.keychain = colorList;
			levelData.player.health = _healthRef.Value;

			levelData.enemies = new Dictionary<string, List<Vector3>>();

			var jSonString = JsonUtility.ToJson(levelData);

			Debug.Log(jSonString);
		}
	}

}