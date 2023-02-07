using System.Collections;
using Game.Enemies;
using UnityEngine;

public class SpeedySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _speedyPrefab;
    [SerializeField] private Transform _spawnerPoint;
    private SpeedyStateManager _speedy;

    private void Awake()
    {
        var go = Instantiate(_speedyPrefab, _spawnerPoint.transform.position, Quaternion.identity);
        _speedy = go.GetComponent<SpeedyStateManager>();
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
        _speedy.gameObject.SetActive(true);
        _speedy.Revive();
    }
}
