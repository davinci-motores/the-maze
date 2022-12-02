using System;
using System.Collections;
using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] private FloatEventSO _playerHealthEvent;
	[SerializeField] private FloatSO _maxPlayerHealth;
	[SerializeField] private FloatSO _playerHealth;
	[Header("Screens")]
	[SerializeField] private GameObject _gameOverScreen;
	[SerializeField] private GameObject _victoryScreen;
	[SerializeField] private GameObject _pauseScreen;
	[Header("Events")]
	[SerializeField] private EventSO _wonEvent;

	private bool _isPause = false;

	public void SetPause()
	{
		_isPause = !_isPause;
		SetActiveScreen(_pauseScreen, _isPause);
	}

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		_playerHealth.Value = _maxPlayerHealth.Value;
		_gameOverScreen.SetActive(false);
		_victoryScreen.SetActive(false);
		_pauseScreen.SetActive(false);
	}

	private void OnEnable()
	{
		_playerHealthEvent.RegisterListener(ChangePlayerHealthHandler);
		_wonEvent.RegisterListener(WonEventHandler);
	}

	private void OnDisable()
	{
		_playerHealthEvent.RegisterListener(ChangePlayerHealthHandler);
		_wonEvent.RegisterListener(WonEventHandler);
	}

	private void WonEventHandler()
	{
		StartCoroutine(CO_WaitForSeconds(3f, Won));
	}

	private void Won()
	{
		SetActiveScreen(_victoryScreen,true);
	}

	private void GameOver()
	{
		SetActiveScreen(_gameOverScreen,true);
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
		yield return new WaitForSeconds(seconds);
		callback();
	}
}
