using System;
using System.Collections;
using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private FloatEventSO _playerHealth;
	[SerializeField] private GameObject _gameOverScreen;
	[SerializeField] private EventSO _wonEvent;

	private void Awake()
	{
		_gameOverScreen.SetActive(false);
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
		
	}

	private void ChangePlayerHealthHandler(float health)
	{
		if (health <= 0)
			StartCoroutine(CO_GameOver(3f));
	}

	IEnumerator CO_GameOver(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		_gameOverScreen.SetActive(true);
	}
}
