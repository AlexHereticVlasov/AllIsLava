using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBall : FireBall
{
    [SerializeField] private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.AddForce(-Physics.gravity);
    }
}
