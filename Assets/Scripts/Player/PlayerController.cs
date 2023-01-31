using System.Collections.Generic;
using Game.ScriptableObjects;
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
		[SerializeField] private Animator _anim;
		[SerializeField] private string _isWalkingParameter, _isRunningParameter, _deathAnimation /*variable agregada para animacion de muerte*/;
		[SerializeField] private InteractableTrigger _interactableTrigger;
		private Vector3 _direction;
		private List<ColorEnum> _keychain = new List<ColorEnum>();
		[SerializeField] private EventSO _wonEvent;
		public bool _controlsActive = true;

		private void OnEnable()
		{
			_wonEvent.RegisterListener(WonHandler);
		}

		private void OnDisable()
		{
			_wonEvent.UnregisterListener(WonHandler);
		}

		private void Update()
		{
			var dirForward = _camera.forward * _direction.z;
			var dirRight = _camera.right * _direction.x;
			var dir = dirForward + dirRight;
			dir.y = 0;
			_characterController.Move(dir.normalized * Time.deltaTime * _movementSpeed);
		}
		public float Speed
		{
			get => _movementSpeed;
			set => _movementSpeed = value;
		}
		public List<ColorEnum> Keychain
		{
			get => _keychain;
			set => _keychain = value;
		}

		public void IsRunning(bool isRunning)
		{
			_anim.SetBool(_isRunningParameter, isRunning);
		}

		public void Movement(InputAction.CallbackContext context)
		{
			if (!_controlsActive) return;
			var contextDirection = context.ReadValue<Vector2>(); //solo se llama cuando el value cambia
			_direction = new Vector3(contextDirection.x, 0, contextDirection.y);
			_anim.SetBool(_isWalkingParameter, true);
			if (context.canceled)
			{
				_direction = Vector3.zero;
				_anim.SetBool(_isWalkingParameter, false);
			}
		}

		public void Interact(InputAction.CallbackContext context)
		{
			if (!_controlsActive) return;
			if (context.performed)
			{
				_interactableTrigger.InteractAction();
			}
		}

		public void AddKey(ColorEnum key)
		{
			Keychain.Add(key);
		}

		public bool HasKey(ColorEnum color)
		{
			var _keyIndex = Keychain.FindIndex(key => key == color);
			return _keyIndex != -1; //lo encontro (?): true | false
		}

		private void WonHandler()
		{
			_controlsActive = false;
			_direction = Vector3.zero;
			_anim.SetBool(_isWalkingParameter, false);
			_anim.SetTrigger("Dance");
		}

		public void PlayerDeath() //metodo de muerte del player, desactivo su movilidad, y activo la animacion
		{
			_controlsActive = false;
			_anim.Play(_deathAnimation);
		}
	}
}
