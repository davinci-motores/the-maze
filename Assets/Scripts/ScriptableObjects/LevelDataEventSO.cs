using System;
using Game.SavingSystem;
using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelDataEvent", menuName = "ScriptableObjects/Event/levelDataEvent", order = 0)]
    public class LevelDataEventSO : ScriptableObject //TPFinal -  Matias Diaz
    {
        private event Action<LevelData> _listeners;

        public void Raise(LevelData levelData)
        {
            _listeners.Invoke(levelData);
        }

        public void RegisterListener(Action<LevelData> listener)
        {
            _listeners += listener;
        }

        public void UnregisterListener(Action<LevelData> listener)
        {
            _listeners -= listener;
        }
    }
}