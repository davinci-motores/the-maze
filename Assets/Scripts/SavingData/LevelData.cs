using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;


namespace Game.SavingSystem
{
	public struct LevelData
	{
		public PlayerData player;

		public Dictionary<string, List<Vector3>> enemies;



	}

	public class PlayerData
	{
		public float health;
		public Vector3 position;
		public List<ColorEnum >keychain;
	}

}
