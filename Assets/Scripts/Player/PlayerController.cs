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
		private Vector3 direction;
		private List<Key> _keychain = new List<Key>();
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private Animator _anim;
		[SerializeField] private string _walkingParameter, _runningParameter;
		
		private void Update()
		{
			_characterController.Move(direction.normalized * Time.deltaTime *_movementSpeed);
		}

		public float Speed
		{
			get => _movementSpeed; set => _movementSpeed = value;
		}

		
		public void IsRunning(bool isRunning)
		{
			_anim.SetBool(_runningParameter, isRunning);
			
		}

		public void Movement(InputAction.CallbackContext context)
		{
			var contextDirection = context.ReadValue<Vector2>(); //solo se llama cuando el value cambia
			direction = new Vector3(contextDirection.x, 0, contextDirection.y);
			_anim.SetBool(_walkingParameter ,true);
			if (context.canceled)
			{
				direction = Vector3.zero;
				_anim.SetBool(_walkingParameter, false);
			}

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
