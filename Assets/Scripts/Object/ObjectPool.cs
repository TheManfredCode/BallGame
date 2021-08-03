using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        Initialize();
    }

    public void Restart()
    {
        foreach (var poolObject in _pool)
            poolObject.SetActive(false);
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);
        return result != null;
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject poolObject = Instantiate(_template, _container.transform);
            poolObject.SetActive(false);

            _pool.Add(poolObject);
        }
    }
}
