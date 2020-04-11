using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class HighScore : MonoBehaviour
{
    private const string SaveName = "HighScore.sav";
    public const int MaxLenght = 20;

    private static ScoreList _scoreList;
    [SerializeField] private ScoreCell[] _cells;

    private void Awake()
    {
        _scoreList = Saver.LoadData<ScoreList>(SaveName);
        if (_scoreList == null)
        {
            _scoreList = new ScoreList();
            Saver.SaveData(_scoreList, SaveName);
        }
        FillTable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Application.isEditor)
            {
                Debug.Log(SaveName + " deleted");
                ClearTable();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Application.isEditor)
            {
                foreach (var num in _scoreList.Score)
                {
                    Debug.Log(num);
                }
            }
        }
    }

    public static void AddScore(int value)
    {
        _scoreList.Score.Add(value);

        _scoreList.Score = (from i in _scoreList.Score
                           orderby i descending
                           select i).ToList();

        while (_scoreList.Score.Count > MaxLenght)
        {
            _scoreList.Score.RemoveAt(_scoreList.Score.Count - 1);
        }
        
        Saver.SaveData(_scoreList, SaveName);
    }

    public void ClearTable()
    {
        Saver.DeleteFile(SaveName);
        _scoreList = new ScoreList();
        Saver.SaveData(_scoreList, SaveName);
        FillTable();
    }

    private void FillTable()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetData(i + 1, _scoreList.Score[i]);
        }
    }
}
