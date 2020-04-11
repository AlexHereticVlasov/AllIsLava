using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Game _game;
    [SerializeField] private Leaper _leaper;
    [SerializeField] private Holder _holder;
    [Header("UI")]
    [SerializeField] private Image _reminder;
    [SerializeField] private Image _shoot;
    //[SerializeField] private Slider _energy;
    [SerializeField] private Image _energy;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _game.OnLeaperSpawn += OnLeaperSpawn;
    }

    private void OnDisable()
    {
        _game.OnReminderChange -= OnReminderChange;
        _game.OnShootChange -= OnShootChange;
        _game.OnEnergyChange -= OnEnergyChange;
        _game.OnLeaperSpawn -= OnLeaperSpawn;
    }

    private void OnReminderChange(float value)
    {
        _reminder.fillAmount = value;
    }

    private void OnShootChange(float obj)
    {
        throw new System.NotImplementedException();
    }

    private void OnPositionChange(int score)
    {
        _score.text = score.ToString();
    }

    private void OnEnergyChange(float amount)
    {
        _energy.fillAmount = amount;
    }

    private void OnLeaperDeath()
    {
        _reminder.gameObject.SetActive(false);

        _leaper.OnLeaperDeath -= OnLeaperDeath;
        _holder.OnPositionChange -= OnPositionChange;
    }

    private void OnLeaperSpawn(Leaper leaper)
    {
        _leaper = leaper;
        _leaper = FindObjectOfType<Leaper>();
        _leaper.OnLeaperDeath += OnLeaperDeath;
        _game.OnReminderChange += OnReminderChange;
        _game.OnShootChange += OnShootChange;
        _game.OnEnergyChange += OnEnergyChange;
        _holder.OnPositionChange += OnPositionChange;
    }
}
