using System.Collections.Generic;
using Game.Objects.Interactables;
using UnityEngine;

namespace Game.Player
{
    public class InteractableTrigger : MonoBehaviour //Matias Diaz
    {
        [SerializeField] private List<IInteractable> _interactableList = new List<IInteractable>();

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable == null) return;

            _interactableList.Add(interactable);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable == null) return;

            _interactableList.Remove(interactable);
        }

        public void InteractAction()
        {
            if (_interactableList.Count > 0)
            {
                _interactableList[_interactableList.Count - 1]?.Interact();
            }
        }
    }
}
