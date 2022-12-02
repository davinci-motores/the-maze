using System;
using System.Collections;
using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private FloatEventSO _playerHealth;
	[SerializeField] private GameObject _gameOverScreen;
	[SerializeField] private GameObject _victoryScreen;
	[SerializeField] private EventSO _wonEvent;

	private void Awake()
	{
		_gameOverScreen.SetActive(false);
		_victoryScreen.SetActive(false);
	}

	private void OnEnable()
	{
		_playerHealth.RegisterListener(ChangePlayerHealthHandler);
		_wonEvent.RegisterListener(WonEventHandler);
	}

	private void OnDisable()
	{
		_playerHealth.RegisterListener(ChangePlayerHealthHandler);
		_wonEvent.RegisterListener(WonEventHandler);
	}

	private void WonEventHandler()
	{
		StartCoroutine(CO_WaitForSeconds(3f, Won));
	}

	private void Won()
	{
		_victoryScreen.SetActive(true);
	}

	private void GameOver()
	{
		_gameOverScreen.SetActive(true);
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
