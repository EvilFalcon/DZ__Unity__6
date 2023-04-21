using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner_Script : MonoBehaviour
{
    [SerializeField] public GameObject prifab;
    private WaitForSeconds _spawnDelay = new WaitForSeconds(2f);

    private Coroutine _coroutine;
    
    private List<Spawn_Point> _spawnPoints;

    private void Awake()
    {
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
        _spawnPoints = GetComponentsInChildren<Spawn_Point>().ToList();
        
    }

    private IEnumerator Coroutine()
    {
        foreach (var point in _spawnPoints)
        {
            point.Spawn(prifab);
       
            yield return _spawnDelay;
        }
    }
}
