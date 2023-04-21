using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Unit _prefab;
        [SerializeField, Range(0f, 10f)] private float _waitSeconds;
    
        private WaitForSeconds _spawnDelay;
        private Coroutine _coroutine;
        private List<Vector3> _spawnPointsPositions=new List<Vector3>();

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
            Transform[] spawnPoints = GetComponentsInChildren<Transform>();

            foreach (var spawnPoint in spawnPoints)
            {
                _spawnPointsPositions.Add(spawnPoint.position);
            }
        }

        private IEnumerator Coroutine()
        {
            foreach (var spawnPointPosition in _spawnPointsPositions)
            {
                Spawn(spawnPointPosition);

                yield return _spawnDelay;
            }
        }

        private void Spawn(Vector3 position)
        {
            Instantiate(_prefab, position,Quaternion.identity);
        }
    }
}