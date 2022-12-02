using UnityEngine;
using Utils;
using System.Collections;
using Game.Player;
using UnityEngine.AI;

namespace Game.Objects.Interactables
{
	public class Door : MonoBehaviour, IInteractable
	{
		[field: SerializeField]
		public ColorEnum Color { get; private set; } = ColorEnum.Null;
		[SerializeField] private float _timeWithDoorOpen =10;
		[SerializeField] private NavMeshObstacle _obstacle;

		public bool IsUnlocked { get; private set; } = false;
		private GameObject _player;
		
		private void Awake()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			IsUnlocked = false;
			_obstacle.enabled = true;
		}
		[ContextMenu("Interact")]
		public void Interact()
		{
			if (_player.GetComponent<PlayerController>().HasKey(Color))
			{
				IsUnlocked = true;
				_obstacle.enabled = false;
				Open();
			}
			else 
			{
				Debug.Log("I can't open this door, I need a key to do that.");
			}
		}

		[ContextMenu ("Open")]
        public void Open()
		{
			
			if (IsUnlocked)
			{
				StartCoroutine(OpenDoor());
			}
			else
			{
				Debug.Log("No puedo abrir la puerta");
			}
		}  

		IEnumerator OpenDoor()
		{			
			this.GetComponent<MeshRenderer>().enabled = false;
			this.GetComponent<BoxCollider>().enabled = false;
			yield return new WaitForSeconds(_timeWithDoorOpen);
			this.GetComponent<MeshRenderer>().enabled = true;
			this.GetComponent<BoxCollider>().enabled = true;
		}

	}
}
