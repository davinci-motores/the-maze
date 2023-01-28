using System;
using System.Collections.Generic;
using Utils;

namespace Game.SavingSystem
{
	[Serializable]
	public struct PlayerData
	{
		public float health;
		public PositionData position;
		public List<ColorEnum >keychain;
	}
}
