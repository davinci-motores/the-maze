using Game.SavingSystem;

namespace DefaultNamespace
{
    public interface IDataPersistence
    {
        public void LoadHandler(LevelData levelData);
    }
}