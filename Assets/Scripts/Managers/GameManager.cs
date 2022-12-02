using System.Collections;
using Game.ScriptableObjects;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private FloatEventSO _playerHealth;
	[SerializeField] private GameObject _gameOverScreen;

	private void Awake()
	{
		_gameOverScreen.SetActive(false);
		_playerHealth.RegisterListener(ChangePlayerHealthHandler);
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
