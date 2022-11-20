using UnityEngine;
using Utils;
using System.Collections;
using Game.Player;

namespace Game.Objects.Interactables
{

	public class Door : MonoBehaviour, IInteractable
	{
		[field: SerializeField]
		public ColorEnum Color { get; private set; } = ColorEnum.Null;
		[SerializeField] private float _timeToOpenDoor =10;

		public bool unlocked, hasKey;
		private GameObject _player;
		
		
		private void Awake()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			unlocked = false;
		}
		[ContextMenu("Interact")]
		public void Interact()
		{
			if (_player.GetComponent<PlayerController>().HasKey(Color))
			{
				Debug.Log("I have a key and I'm going to open the door.");
				unlocked = true;
				Open();
			}
			else 
			{
				Debug.Log("I can't open this door, I need a key to do that.");
			}
		}

		[ContextMenu ("Open")]
        private void Open()
		{
			
			if (unlocked)
			{
				//abrir la puerta
				Debug.Log("Abrir la puerta");
				StartCoroutine(OpenDoor());
			}
			else
			{
				//no se abre 
				Debug.Log("No puedo abrir la puerta");
			}
		}

		IEnumerator OpenDoor()
		{			
			this.GetComponent<MeshRenderer>().enabled = false;
			this.GetComponent<BoxCollider>().enabled = false;
			yield return new WaitForSeconds(_timeToOpenDoor);
			this.GetComponent<MeshRenderer>().enabled = true;
			this.GetComponent<BoxCollider>().enabled = true;
		}

	}
}
