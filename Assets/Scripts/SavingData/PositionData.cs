using System;

namespace Game.SavingSystem
{
    [Serializable]
    public struct PositionData
    {
        public float x;
        public float y;
        public float z;

        public PositionData(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}