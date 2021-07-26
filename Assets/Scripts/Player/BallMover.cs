using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.velocity = new Vector3(_speed, 0, 0);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector3(_speed, 0, 0);

        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
        _isGrounded = false;
    }
}
