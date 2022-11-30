using System;
using Game.Objects.Interactables;
using UnityEngine;

namespace Game.Components
{
    public class OpenDoorComponent : MonoBehaviour
    {
        public event Action OnDoorDetected;
        private Door _currentDoor = null;

        public bool Open()
        {
            if (_currentDoor == null) return false;

            if (!_currentDoor.IsUnlocked) return false;

            _currentDoor.Open();
            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Door")) return;
            _currentDoor = other.gameObject.GetComponentInChildren<Door>();
            OnDoorDetected?.Invoke();
        }
    }
}