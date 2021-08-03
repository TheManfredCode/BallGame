using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnRate;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnRate)
        {
            if (TryGetObject(out GameObject poolObject))
            {
                _elapsedTime = 0;

                poolObject.SetActive(true);
                poolObject.transform.position = _spawnPoint.position;
            }
        }
    }
}
