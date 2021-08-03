using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMover))]
public class PlayerInput : MonoBehaviour
{
    private BallMover _mover;

    private void Start()
    {
        _mover = GetComponent<BallMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if(_mover.IsGrounded)
                _mover.Jump();
    }
}
