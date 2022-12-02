using Game.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private FloatSO _playerHealth;


	private void Update()
	{
		if (_playerHealth.Value <=0 )
		{
			
			GameOver();
		}
	}

	private void GameOver()
	{
		Debug.Log("El player murio");
	}
}
