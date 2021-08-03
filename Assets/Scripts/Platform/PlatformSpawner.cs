using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private float _spawnOffset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Vector3 spawnPoint = transform.position;
            spawnPoint.x = transform.position.x + _spawnOffset;

            _platform.gameObject.SetActive(true);
            _platform.transform.position = spawnPoint;
        }
    }
}
