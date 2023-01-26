using System;
using Game.Objects.Interactables;
using UnityEngine;

namespace Game.Components
{
    public class OpenDoorComponent : MonoBehaviour
    {
        public event Action OnDoorDetected;
        private Door _currentDoor = null;

        public void Open()
        {
            if (_currentDoor == null) return;

            if (!_currentDoor.IsUnlocked) return;

            _currentDoor.Open();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Door")) return;
            _currentDoor = other.gameObject.GetComponentInChildren<Door>();
            OnDoorDetected?.Invoke();
        }
    }
}