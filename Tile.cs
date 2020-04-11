using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Tile : MonoBehaviour
{
    [SerializeField] private TilesList _tilesList;
    private bool _wasActivated = false;
    
    protected void OnTriggerEnter(Collider other)
    {
        Leaper leaper = other.GetComponent<Leaper>();
        if (leaper != null)
        {
            Activate();
        }
    }

    protected void SpawnNextTile()
    {
        Instantiate(_tilesList.Tiles[Random.Range(0, _tilesList.Tiles.Length)],
            transform.position + Game.TileOffset * 2,
            Quaternion.identity);
    }

    protected virtual void Activate()
    {
        if (!_wasActivated)
        {
            _wasActivated = true;
            SpawnNextTile();
            //Destroy(this);
        }
    }
}
