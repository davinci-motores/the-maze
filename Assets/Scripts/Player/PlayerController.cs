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
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private Transform _camera;
		private Vector3 _direction;
		private List<Key> _keychain = new List<Key>();
		[SerializeField] private Animator _anim;
		[SerializeField] private string _walkingParameter, _runningParameter;
		
		private void LateUpdate()
		{
			var dirForward = _camera.forward * _direction.z;
			var dirRight = _camera.right * _direction.x;
			var dir = dirForward + dirRight;
			dir.y = 0;
			_characterController.Move(dir.normalized * Time.deltaTime *_movementSpeed);
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
			_direction = new Vector3(contextDirection.x, 0, contextDirection.y);
			_anim.SetBool(_walkingParameter ,true);
			if (context.canceled)
			{
				_direction = Vector3.zero;
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
