using Game.Player;
using UnityEngine;
using Utils;

namespace Game.Objects.Interactables
{
    //TPFinal - Gabriel Rodriguez.
    public class Key : MonoBehaviour, IInteractable
    {
        private GameObject _player;

        [field: SerializeField]
        public ColorEnum Color { get; private set; } = ColorEnum.Null;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        [ContextMenu("Interact")]
        public void Interact()
        {
            _player.GetComponent<PlayerController>()?.AddKey(Color);
            gameObject.SetActive(false);
        }
    }
    
}