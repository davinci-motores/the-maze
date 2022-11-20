using UnityEngine;

namespace Game.Objects.Interactables
{

	public class Door : IInteractable
	{
		public bool isOpen, hasKey;
		public void Interact()
		{
			if (hasKey)
			{
				Debug.Log("I have a key and I'm going to open the door.");
				Open();
			}
			else
			{
				Debug.Log("I can't open this door, I need a key to do that.");
			}
		}

        private void Open()
		{
			Debug.Log("I opened the door.");
			isOpen = true;
		}
	}
}
