using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FireBall : MonoBehaviour, IDamageble
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _deathEffect;
    
 
    private void OnCollisionEnter(Collision collision)
    {
        Leaper leaper = collision.gameObject.GetComponent<Leaper>();
        if (leaper != null)
        {
            leaper.Die();
            Die();
        }
    }

    private void OnEnable()
    {
        float chance = Random.value;
        if (chance > .5f)
            Die();
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
            Die();
    }

    public void SpawnDeathEffect()
    {
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(1.5f, 2, 1, 1);
        Destroy(effect, Game.EffectLifeTime);
    }
}
