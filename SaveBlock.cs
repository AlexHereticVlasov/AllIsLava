using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBlock : MonoBehaviour, IDamageble
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _deathEffect;

    private float _health = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Leaper leaper = collision.gameObject.GetComponent<Leaper>();
        if (leaper != null)
        {
            _rigidbody.isKinematic = false;
        }
    }

    public void Die()
    {
        SpawnDeathEffect();
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
        GameObject effet = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effet, Game.EffectLifeTime);
    }
}
