using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCell : MonoBehaviour
{
    [SerializeField] private Text _place;
    [SerializeField] private Text _score;

    public void SetData(int place, int score)
    {
        _place.text = place.ToString();
        _score.text = score.ToString();
    }
}
