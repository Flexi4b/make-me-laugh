using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bombo : MonoBehaviour
{
    public static Bombo bombo;

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

    [SerializeField] private TextMeshProUGUI _bombTimerText;

    // GameObjects

    [SerializeField] private GameObject _bombTimerVisual;

    // Misc

    private IEnumerator _activeCoroutine;

    void Start()
    {
        Bombo bombo = this;
        _timer = _selectedBombTime;
        _minutes = _timer / 60;
        _audioSource.clip = _bombTick;
        _bombTimerText.text = "0" + _minutes.ToString("F0") + ":" + _seconds.ToString("F0");
        _BombIsActive = true;
        //Time.timeScale = 2f;
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
        if (_activeCoroutine != null) 
        {
            StartCoroutine(_activeCoroutine);
            _activeCoroutine = null;
        }
    }


    private void BombClock()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _seconds -= Time.deltaTime;

            // Makes the bomb display the time visually correct
            if (_seconds >= 10)
            {
                _bombTimerText.text = "0" + _minutes.ToString("F0") + ":" + _seconds.ToString("F0");
            }
            else if (_seconds < 9)
            {
                _bombTimerText.text = "0" + _minutes.ToString("F0") + ":0" + _seconds.ToString("F0");
            }

            if (_seconds <= 0)
            {
                _minutes -= 1;
                _audioSource.Play();
                _seconds = 59;
            }
        }

        if (_timer <= 1)
        {
            _activeCoroutine = BombExplodes();
            _BombIsActive = false;
        }
    }

    private IEnumerator BombExplodes()
    {
        int repeats = 4;

        _audioSource.clip = _timerExpired;
        _audioSource.Play();
        _bombTimerText.text = "XX:XX";

        for (int i = 0; i < repeats; i++)
        {
            _bombTimerVisual.SetActive(false);
            yield return new WaitForSeconds(0.6f);
            _bombTimerVisual.SetActive(true);
            yield return new WaitForSeconds(0.6f);
        }
        Debug.Log("you fucking suck at this game");
        yield return null;
    }

    public IEnumerator BombDefused()
    {
        int repeats = 4;


        for (int i = 0; i < repeats; i++)
        {
            _bombTimerVisual.SetActive(false);
            yield return new WaitForSeconds(0.6f);
            _bombTimerVisual.SetActive(true);
            yield return new WaitForSeconds(0.6f);
        }

        yield return null;
    }
}
