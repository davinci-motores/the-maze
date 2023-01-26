using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Objects.Interactables
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private Color _activeColor = Color.green;
        [SerializeField] private Color _desactiveColor = Color.red;
        [SerializeField] private EventSO _powerUnitEvent;
        [SerializeField] private Material _material;
        [SerializeField] private EventSO _wonEvent;
        private bool _isActive = false;

        private void OnEnable()
        {
            _powerUnitEvent.RegisterListener(ActiveHandler);
            _material.color = _desactiveColor;
        }

        private void OnDisable()
        { 
            _powerUnitEvent.UnregisterListener(ActiveHandler);
        }

        [ContextMenu("Activate")]
        private void ActiveHandler()
        {
            _isActive = true;
            _material.color = _activeColor;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && _isActive)
            {
                _wonEvent.Raise();
            }
        }
    }    
}

