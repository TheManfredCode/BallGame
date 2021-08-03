using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeScore(_score);
            Deactivate();
        }

        if (other.gameObject.TryGetComponent(out Edge edge))
            Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
