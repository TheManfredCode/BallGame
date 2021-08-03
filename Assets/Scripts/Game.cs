using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ObjectPool[] _objectPools;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    public void OnDied()
    {
        Restart();
    }

    private void Restart()
    {
        _player.Restart();

        foreach (ObjectPool objectPool in _objectPools)
            objectPool.Restart();
    }
}
