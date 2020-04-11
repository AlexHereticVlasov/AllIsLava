using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IDamageble
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _direction = Vector3.right;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _health; 
    

    private void Start()
    {
        _rigidbody.velocity = _direction * (_speed + Holder.Speed);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_direction, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null)
        {
            damageble.TakeDamage(_damage);
        }
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public void SpawnDeathEffect()
    {
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, Game.EffectLifeTime);
    }
}
