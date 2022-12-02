using System;
using System.Collections;
using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private FloatEventSO _playerHealthEvent;
	[SerializeField] private FloatSO _maxPlayerHealth;
	[SerializeField] private FloatSO _playerHealth;
	[SerializeField] private GameObject _gameOverScreen;
	[SerializeField] private GameObject _victoryScreen;
	[SerializeField] private EventSO _wonEvent;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		_playerHealth.Value = _maxPlayerHealth.Value;
		_gameOverScreen.SetActive(false);
		_victoryScreen.SetActive(false);
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
		_victoryScreen.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
	}

	private void GameOver()
	{
		_gameOverScreen.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
	}

	private void ChangePlayerHealthHandler(float health)
	{
		if (health <= 0)
			StartCoroutine(CO_WaitForSeconds(3f, GameOver));
	}

	IEnumerator CO_WaitForSeconds(float seconds, Action callback)
	{
		yield return new WaitForSeconds(seconds);
		callback();
	}
}
