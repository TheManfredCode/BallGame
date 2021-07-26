using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _spawnRate;

    private List<GameObject> _pool = new List<GameObject>();
    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize();
    }

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

    public void Restart()
    {
        foreach (var poolObject in _pool)
            poolObject.SetActive(false);
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_template, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);
        return result != null;
    }
}
