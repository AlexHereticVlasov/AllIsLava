using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollapsingBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void ActivateGravity()
    {
        _rigidbody.isKinematic = false;
    }
}
