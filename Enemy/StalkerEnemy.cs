using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerEnemy : BaseEnemy
{
    private float _health;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _deathEffect;

    private void Start()
    {
        _rigidbody.velocity = Vector3.right * Holder.Speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Leaper leaper = other.GetComponent<Leaper>();
        if (leaper != null)
        {
            leaper.Die();
        }
    }

    protected override void Move()
    {
        _rigidbody.AddForce(Vector3.right, ForceMode.Force);
    }

    protected override void Wait()
    {
        throw new System.NotImplementedException();
    }

    


}
