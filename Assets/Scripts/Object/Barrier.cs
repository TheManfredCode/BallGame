using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            player.Die();

        if (other.gameObject.TryGetComponent(out Edge edge))
            gameObject.SetActive(false);
    }
}
