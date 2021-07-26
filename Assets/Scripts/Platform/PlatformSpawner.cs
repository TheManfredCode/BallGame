using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Platform _template;
    [SerializeField] private float _spawnOffset;

    private Vector3 _spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _spawnPoint = transform.position;
            _spawnPoint.x = transform.position.x + _spawnOffset;

            _template.gameObject.SetActive(true);
            _template.transform.position = _spawnPoint;
        }
    }
}
