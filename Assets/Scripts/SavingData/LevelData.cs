using System;
using System.Collections.Generic;

namespace Game.SavingSystem
{
	[Serializable]
	public struct LevelData
	{
		public PlayerData player;
		public Dictionary<string, List<PositionData>> enemies;
	}
}
