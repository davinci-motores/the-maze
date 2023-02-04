using Game.SavingSystem;

namespace Game
{
    public interface IDataPersistence
    {
        public void LoadHandler(LevelData levelData);
    }
}