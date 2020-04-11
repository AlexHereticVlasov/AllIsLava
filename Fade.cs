using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fade : MonoBehaviour
{
    public const float FadeLenght = 1.5f;

    [SerializeField] private Game _game;
    [SerializeField] private Leaper _leaper;
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName = "Fade";

    private void OnEnable()
    {
        _game.OnLeaperSpawn += OnLeaperSpawn;
        _loader.OnEscape += OnEscape;
    }

    private void OnEscape()
    {
        _animator.SetTrigger(_triggerName);
        _loader.OnEscape -= OnEscape;
    }

    private void OnLeaperSpawn(Leaper leaper)
    {
        _leaper = leaper;
        _leaper.OnLeaperDeath += OnLeaperDeath;
        _game.OnLeaperSpawn -= OnLeaperSpawn;
    }

    private void OnLeaperDeath()
    {
        _animator.SetTrigger(_triggerName);
        _leaper.OnLeaperDeath -= OnLeaperDeath;
    }
}
