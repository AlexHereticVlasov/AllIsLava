using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TilesList" ,menuName = "ScriptableObjects/TilesList")]
public class TilesList : ScriptableObject
{
    [SerializeField] private GameObject[] _tiles;

    public GameObject[] Tiles { get { return _tiles; } }
}
