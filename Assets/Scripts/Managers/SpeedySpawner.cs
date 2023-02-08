using System.Collections;
using Game.Enemies;
using Game.Enemies.SpeedyStates;
using UnityEngine;
using System.Collections.Generic;

public class SpeedySpawner : MonoBehaviour
{
	[SerializeField] private GameObject _speedyPrefab;
	[SerializeField] private Transform _spawnerPoint;
	private SpeedyStateManager _speedy;
	[SerializeField] private List<Transform> waypoints = new List<Transform>();
	[SerializeField] private float _timeToRespawn;

	private void Awake()
	{
		var go = Instantiate(_speedyPrefab, _spawnerPoint.transform.position, Quaternion.identity);
		_speedy = go.GetComponent<SpeedyStateManager>();
		go.GetComponent<NormalState>().WayPoint = waypoints;
		print(waypoints);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != _speedy.gameObject) return;
		if (_speedy.gameObject.activeSelf)
		{
			_speedy.Kill();
		}

		StartCoroutine(CO_Spawn());
	}

	private IEnumerator CO_Spawn()
	{
		while (_speedy.gameObject.activeSelf)
		{
			yield return null;
		}
		_speedy.transform.position = _spawnerPoint.position;
		yield return new WaitForSeconds(_timeToRespawn);
		_speedy.gameObject.SetActive(true);
		_speedy.Revive();
	}
}
