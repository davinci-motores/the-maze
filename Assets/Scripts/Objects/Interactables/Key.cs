using System;
using Game.Player;
using Game.SavingSystem;
using Game.ScriptableObjects;
using UnityEngine;
using Utils;

namespace Game.Objects.Interactables
{
    //TPFinal - Gabriel Rodriguez.
    public class Key : MonoBehaviour, IInteractable, IDataPersistence
    {
        private GameObject _player;
        [SerializeField] private LevelDataEventSO _loadGameEvent;

        [field: SerializeField]
        public ColorEnum Color { get; private set; } = ColorEnum.Null;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _loadGameEvent.RegisterListener(LoadHandler);
        }

        private void OnDestroy()
        {
            _loadGameEvent.UnregisterListener(LoadHandler);
        }

        [ContextMenu("Interact")]
        public void Interact()
        {
            _player.GetComponent<PlayerController>()?.AddKey(Color);
            gameObject.SetActive(false);
        }

        public void LoadHandler(LevelData levelData)
        {
            var index = levelData.player.keychain.FindIndex((keyColor) => keyColor == Color);
            if (index == -1) return;
            
            gameObject.SetActive(false);
        }
    }
}