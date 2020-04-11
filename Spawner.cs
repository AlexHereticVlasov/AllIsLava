using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 15f));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var i =  Random.Range(0, _enemies.Length);
        var j = Random.Range(0, _spawnPoints.Length);

        GameObject enemy = Instantiate(_enemies[i], _spawnPoints[j].position, Quaternion.identity);
    }
}
