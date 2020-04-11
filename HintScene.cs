using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HintScene : MonoBehaviour
{
    private bool _isSkiped = false;
    private float _fadeTime = 1f;
    private float _readTime = 3f;


    [SerializeField] private Animator _fadeAnimator;
    [SerializeField] private Animator _hintAnimator;
    [SerializeField] private Text _hint;
    [SerializeField] private string[] _hints;
    //[SerializeField] private string _sceneName = "Game";
    [SerializeField] private string _fade = "Fade";

    private void Start()
    {
        StartCoroutine(ShowHint());
        StartCoroutine(LoadGame(_readTime * _hints.Length));
    }

    private void Update()
    {
        if (!_isSkiped)
        {
            if (Input.anyKey)
            {
                _isSkiped = true;
                StartCoroutine(LoadGame(0));
            }
        }
    }

    private IEnumerator LoadGame(float time)
    {
        yield return new WaitForSeconds(time);
        _fadeAnimator.SetTrigger(_fade);
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene((int) Scenes.Game);
    }

    private IEnumerator ShowHint()
    {
        for (int i = 0; i < _hints.Length; i++)
        {
            _hintAnimator.SetTrigger(_fade);
            _hint.text = _hints[i];
            yield return new WaitForSeconds(_readTime);
        }
    }
}
