using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
	public class PlayerController : MonoBehaviour
	{
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

		public void DoubleSpeedBy(float seconds)
		{
			Debug.Log("Se duplico la speed");
		}
	}	
}
