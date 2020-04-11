using System.Collections;
using System;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public event Action<int> OnPositionChange;

    private const float IncreaseRate = 30;
    private const float IncreaseValue = .5f;
    private const float NormalXPosition = -15;

    public static float Speed { get; private set; } = 5;

    [SerializeField] private Game _game;
    [SerializeField] private Leaper _leaper;
    [SerializeField] private Transform _leaperPosition;
    [SerializeField] private float _startSpeed = 5;

    private bool _isMooving = true;

    private int _currentXPosition;
    private int _lastXPosition;

    private void Start()
    {
        Speed = _startSpeed;
        StartCoroutine(IncreaseSpeed());
    }

    private void OnEnable()
    {
        _game.OnLeaperSpawn += OnLeaperSpawn;
    }

    private void OnLeaperSpawn(Leaper leaper)
    {
        _leaper = leaper;
        _leaperPosition = _leaper.transform;
        _leaper.OnLeaperDeath += OnLeaperDeath;
    }

    private void OnLeaperDeath()
    {
        HighScore.AddScore((int)transform.position.x);
        _leaper.OnLeaperDeath -= OnLeaperDeath;
        _isMooving = false;
    }

    private void Update()
    {
        Move();
        CorrectPosition();
        CalculatePosition();
    }

    private void CorrectPosition()
    {
        if (_leaperPosition.localPosition.x > NormalXPosition + 1 || _leaperPosition.localPosition.x < NormalXPosition - 1)
        {
            _leaperPosition.localPosition = Vector3.MoveTowards(_leaperPosition.localPosition,
                new Vector3(NormalXPosition, _leaperPosition.localPosition.y, 0),
                Speed * Time.deltaTime);
        }
    }

    private void CalculatePosition()
    {
        _currentXPosition = (int)transform.position.x;
        if (_currentXPosition != _lastXPosition)
        {
            OnPositionChange?.Invoke(_currentXPosition);
        }
        _lastXPosition = _currentXPosition;
    }

    private void Move()
    {
        if (_isMooving)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                transform.position + Vector3.right,
                Time.deltaTime * Speed);
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(IncreaseRate);
            Speed += IncreaseValue;
        }
    }
}
