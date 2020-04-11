using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreList
{
    public List<int> Score { get; set; }

    public ScoreList()
    {
        Score = new List<int>();
        while (Score.Count < HighScore.MaxLenght)
        {
            Score.Add(default);
        }
    }
}