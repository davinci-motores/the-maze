using System;
using System.Collections;
using Game.HUD;
using Game.ScriptableObjects;
using UnityEngine;
using Game.Player;


namespace Game.Managers
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; set; }
		public static LoadType loadType;
		
		[Header("Player")]
		[SerializeField] private FloatEventSO _playerHealthEvent;
		[SerializeField] private FloatSO _maxPlayerHealth;
		[SerializeField] private FloatSO _playerHealth;
		[SerializeField] private PlayerController _playerRef; //referencia al player controller
		[Header("Screens")]
		[SerializeField] private GameObject _gameOverScreen;
		[SerializeField] private GameObject _victoryScreen;
		[SerializeField] private GameObject _pauseScreen;
		[Header("Events")]
		[SerializeField] private EventSO _wonEvent;
		[Header("HUD")]
		[SerializeField] private PowerUpUI _powerUpUI;
		[SerializeField] private LoadManager _loadManager;

		private bool _isPause = false;


		private void OnDestroy()
		{
			_playerHealthEvent.RegisterListener(ChangePlayerHealthHandler);
			_wonEvent.RegisterListener(WonEventHandler);
		}

		public void SetPause()
		{
			_isPause = !_isPause;
			SetActiveScreen(_pauseScreen, _isPause);
		}

		private void Awake()
		{
			Instance = this;
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			_playerHealthEvent.RegisterListener(ChangePlayerHealthHandler);
			_wonEvent.RegisterListener(WonEventHandler);
			_playerHealth.Value = _maxPlayerHealth.Value;
			_gameOverScreen.SetActive(false);
			_victoryScreen.SetActive(false);
			_pauseScreen.SetActive(false);
			
		}

		private void Start()
		{
			if (loadType == LoadType.LoadGame)
			{
				_loadManager.LoadGame();
			}
		}

		private void WonEventHandler()
		{
			StartCoroutine(CO_WaitForSeconds(3f, Won));
		}

		private void Won()
		{
			SetActiveScreen(_victoryScreen, true);
		}

		private void GameOver()
		{
			SetActiveScreen(_gameOverScreen, true);
		}

		private void ChangePlayerHealthHandler(float health)
		{
			if (health <= 0)
				StartCoroutine(CO_WaitForSeconds(3f, GameOver));
		}

		private void SetActiveScreen(GameObject screen, bool active)
		{
			screen.SetActive(active);
			Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
			Time.timeScale = active ? 0 : 1;
		}

		IEnumerator CO_WaitForSeconds(float seconds, Action callback)
		{
			_playerRef.PlayerDeath();
			yield return new WaitForSeconds(seconds);
			callback();
		}

		public void ActivatePowerUp(Color color)
		{
			_powerUpUI.SetColor(color);
		}

		public void DefaultPowerUp()
		{
			_powerUpUI.SetDefaultColor();
		}
	}

	public enum LoadType
	{
		NewGame,
		LoadGame
	}
}
