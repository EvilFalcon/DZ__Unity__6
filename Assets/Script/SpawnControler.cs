using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnControler : MonoBehaviour
{
    [SerializeField] private Unit _prefab;
    [SerializeField, Range(0f, 10f)] private float _waitSeconds;
    
    private WaitForSeconds _spawnDelay;
    private Coroutine _coroutine;
    private List<Point> _spawnPoints;

    private void Awake()
    {
        _spawnDelay = new WaitForSeconds(_waitSeconds);
        GetSpawnerPoint();
    }

    private void OnEnable()
    {
        if (_coroutine is not null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Coroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void GetSpawnerPoint()
    {
        _spawnPoints = GetComponentsInChildren<Point>().ToList();
    }

    private IEnumerator Coroutine()
    {
        foreach (var point in _spawnPoints)
        {
            point.Spawn(_prefab);

            yield return _spawnDelay;
        }
    }
}