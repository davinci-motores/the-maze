using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _movementSpeed;
		

		


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
