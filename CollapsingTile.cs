using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingTile : Tile
{
    [SerializeField] private List<CollapsingBlock> _blocks;

    protected override void Activate()
    {
        SpawnNextTile();
        StartCoroutine(Collapse());
    }

    private IEnumerator Collapse()
    {
        while (_blocks.Count > 0)
        {
            int i = Random.Range(0, _blocks.Count);
            _blocks[i].ActivateGravity();
            _blocks.Remove(_blocks[i]);
            yield return new WaitForSeconds(.2f);
        }
    }
}
