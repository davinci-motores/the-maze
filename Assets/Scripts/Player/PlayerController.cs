using System.Collections.Generic;
using Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Game.SavingSystem;

namespace Game.Player
{
	//TPFinal -  Gabriel Rodriguez
	public class PlayerController : MonoBehaviour, IDataPersistence
	{
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private Transform _camera;
		[SerializeField] private Animator _anim;
		[Header("Animaciones")]
		[SerializeField] private string _isWalkingParameter, _isRunningParameter, _deathAnimation;
		[Space]
		[SerializeField] private InteractableTrigger _interactableTrigger;
		private Vector3 _direction;
		private List<ColorEnum> _keychain = new List<ColorEnum>();
		[SerializeField] private LevelDataEventSO _loadEvent;
		[SerializeField] private EventSO _wonEvent;
		public bool _controlsActive = true;
		[SerializeField, Range(0f, 100f)] private float _rotationSpeed = 15;

		private void OnEnable()
		{
			_wonEvent.RegisterListener(WonHandler);
			_loadEvent.RegisterListener(LoadHandler);
		}

		private void OnDisable()
		{
			_wonEvent.UnregisterListener(WonHandler);
			_loadEvent.UnregisterListener(LoadHandler);
		}

		private void Update()
		{
			var dirForward = _camera.forward * _direction.z;
			var dirRight = _camera.right * _direction.x;
			var dir = dirForward + dirRight;
			dir.y = 0;
			_anim.transform.forward = Vector3.Lerp(_anim.transform.forward, dir.normalized, Time.deltaTime * _rotationSpeed);
			_characterController.Move(dir.normalized * Time.deltaTime * _movementSpeed);
		}

		private void LateUpdate()
		{
			var newPosition = transform.position;
			newPosition.y = 0f;
			transform.position = newPosition;
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
			var contextDirection = context.ReadValue<Vector2>();
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
			return _keyIndex != -1;
		}

		private void WonHandler()
		{
			_controlsActive = false;
			_direction = Vector3.zero;
			_anim.SetBool(_isWalkingParameter, false);
			_anim.SetTrigger("Dance");
		}

		public void PlayerDeath()
		{
			_controlsActive = false;
			_anim.Play(_deathAnimation);
		}
		
		public void LoadHandler(LevelData levelData)
		{
			_characterController.enabled = false;
			_controlsActive = false;

			var positionData =  levelData.player.position;
			var vectorPositionData = new Vector3(positionData.x,positionData.y, positionData.z);
			transform.position = vectorPositionData;

			_characterController.enabled = true;
			_controlsActive = true;
		}
	}
}
