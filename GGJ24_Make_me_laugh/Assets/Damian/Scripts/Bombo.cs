using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bombo : MonoBehaviour
{

    // Floats

    [Tooltip("This sets the time for the bomb")]
    [SerializeField] private float _selectedBombTime;

    private float _timer;
    private float _seconds;
    private float _minutes;

    // Bools

    [HideInInspector] public bool _BombIsActive;
    [HideInInspector] public bool _BombHasBeenDefused;

    // Sound Related

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _bombTick;
    [SerializeField] private AudioClip _timerExpired;
    [SerializeField] private AudioClip _bombExplode;

    // UI Related

    [SerializeField] private TextMeshProUGUI _bombTimerVisual;

    void Start()
    {
        _timer = _selectedBombTime;
        _minutes = _timer / 60;
        _audioSource.clip = _bombTick;
    }

    
    void Update()
    {
        if (_BombIsActive)
        {
            BombClock();
        }

        if (_BombHasBeenDefused)
        {
            _BombIsActive = false;
            StartCoroutine(BombDefused());
        }
    }


    private void BombClock()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _seconds -= Time.deltaTime;
            if (_seconds <= 0)
            {
                _seconds = 60;
            }
        }

        if (_timer <= 0)
        {
            StartCoroutine(BombExplodes());
        }
    }

    private void TimerDisplay()
    {

    }

    private IEnumerator BombExplodes()
    {
        yield return null;
    }

    private IEnumerator BombDefused()
    {
        yield return null;
    }
}
