using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Key = Game.Objects.Interactables.Key;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _movementSpeed;
		private List<Key> _keychain = new List<Key>();

		public void Movement(InputAction.CallbackContext context)
		{
			var contexto = context.ReadValue<Vector2>(); //solo se llama cuando el value cambia
			Debug.Log(contexto);
		}

		public void Interact(InputAction.CallbackContext context)
		{
			if (context.performed) //cuando el context es presionado
			{
				Debug.Log("Interactua");
			}
		}

		public void AddKey(Key key)
		{
			_keychain.Add(key);
		}

		public bool HasKey(ColorEnum color)
		{
			var _keyIndex = _keychain.FindIndex(key => key.Color == color);
			return _keyIndex != -1 ? true : false;
		}

		public void ActiveEffect(Action<PlayerController> effect, Action<PlayerController> back)
		{
			StartCoroutine(CO_ActiveEffect(effect, back));
		}

		private IEnumerator CO_ActiveEffect(Action<PlayerController> effect, Action<PlayerController> back)
		{
			effect(this);
			yield return new WaitForSeconds(2);
			back(this);
		}
	}	
}
