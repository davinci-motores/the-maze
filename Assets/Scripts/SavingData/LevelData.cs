using System;
using System.Collections.Generic;

namespace Game.SavingSystem
{
	[Serializable]
	public struct LevelData //TPFinal - * Federico Krug *.
	{
		public PlayerData player;
		public Dictionary<string, PositionData> enemies;
	}
}
