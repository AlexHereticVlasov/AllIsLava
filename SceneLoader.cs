﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MouseButtons
{
    Left = 0,
    Right = 1,
    Middle = 2
}

public enum Scenes
{
    MainMenu = 0,
    HintScene = 1,
    Game = 2
}

public class SceneLoader : MonoBehaviour
{
    public event Action OnEscape;

    [SerializeField] private Game _game;

    [SerializeField] private Leaper _leaper;

    private bool _isExiting = false;

    private void OnEnable()
    {
        _game.OnLeaperSpawn += OnLeaperSpawn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isExiting)
            {
                StartCoroutine(Escape());
            }
        }
    }

    private void OnDisable()
    {
        _game.OnLeaperSpawn -= OnLeaperSpawn;
    }

    private void OnLeaperSpawn(Leaper leaper)
    {
        leaper.OnLeaperDeath += OnLeaperDeath;
    }

    private void OnLeaperDeath()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(Fade.FadeLenght);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Escape()
    {
        OnEscape?.Invoke();
        yield return new WaitForSeconds(Fade.FadeLenght);
        LoadMenu();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
