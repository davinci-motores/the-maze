using System.Collections;
using Game.Enemies;
using Game.Enemies.SpeedyStates;
using UnityEngine;
using System.Collections.Generic;
using Utils;

public class SpeedySpawner : MonoBehaviour //TPFinal - * Federico Krug *.
{
	[SerializeField] private GameObject _speedyPrefab;
	[SerializeField] private Transform _spawnerPoint;
	[SerializeField] private List<Transform> waypoints = new List<Transform>();
	[SerializeField] private float _timeToRespawn;
	[SerializeField] private ColorEnum _color;
	private SpeedyStateManager _speedy;

	private void Awake()
	{
		var go = Instantiate(_speedyPrefab, _spawnerPoint.transform.position, Quaternion.identity);
		_speedy = go.GetComponent<SpeedyStateManager>();
		go.GetComponent<NormalState>().WayPoint = waypoints;
		go.GetComponent<SpeedyGomezEnemy>().Color = _color;
	}

	private void OnEnable()
	{
		_speedy.onDeath += ReviveSpeedyEnemy;
	}

	private void OnDisable()
	{
		_speedy.onDeath -= ReviveSpeedyEnemy;
		
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != _speedy.gameObject) return;
		if (_speedy.gameObject.activeSelf)
		{
			_speedy.Kill();
		}

	}

	private void ReviveSpeedyEnemy()
	{
		StartCoroutine(CO_Spawn());
	}

	private IEnumerator CO_Spawn()
	{
		yield return null;
		_speedy.transform.position = _spawnerPoint.position;
		yield return new WaitForSeconds(_timeToRespawn);
		_speedy.gameObject.SetActive(true);
		_speedy.Revive();
	}
}
