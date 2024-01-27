using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorRoomMouseMove : MonoBehaviour
{
    private ChangeButtonsColor _changeButtonsColor;

    public bool WeaponEquiped;
    public int FirstWaveSnakesDestroyed;
    public int SecondWaveSnakesDestroyed;
    public int ThirdWaveSnakesDestroyed;
    public int ButtonsPressed;

    public bool HorrorRoomCleard;

    private SnakeSpawner _snakeSpawner;

    void Start()
    {
        _changeButtonsColor = FindObjectOfType<ChangeButtonsColor>();
        _snakeSpawner = FindObjectOfType<SnakeSpawner>();
    }

    void Update()
    {
        OnMouseClick();
    }

    private void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.transform != null)
                {
                    SelectedObject(hit.transform.gameObject);
                }
            }
        }
    }

    private void SelectedObject(GameObject gameObject)
    {
        if (gameObject.CompareTag("ButcherKnife") || gameObject.CompareTag("ChefsKnife") || gameObject.CompareTag("Spatula"))
        {
            WeaponEquiped = true;
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Snake"))
        {
            if (WeaponEquiped)
            {
                Destroy(gameObject);
                FirstWaveSnakesDestroyed += 1;
                SecondWaveSnakesDestroyed += 1;
                ThirdWaveSnakesDestroyed += 1;
            }
        }

        if (_changeButtonsColor.ColorWaveOneDone)
        {
            if (gameObject.CompareTag("BloodyButtons") && gameObject.GetComponent<ButtonActive>().ButtonIsActive == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = _changeButtonsColor.BlackMat;
                ButtonsPressed += 1;
                gameObject.GetComponent<ButtonActive>().ButtonIsActive = false;
            }

            if (ButtonsPressed >= 2)
            {
                _snakeSpawner.SecondWaveBegin = true;
                ButtonsPressed = 0;
                _changeButtonsColor.ColorWaveOneDone = false;
            }
        }

        if (_changeButtonsColor.ColorWaveTwoDone)
        {
            if (gameObject.CompareTag("BloodyButtons") && gameObject.GetComponent<ButtonActive>().ButtonIsActive == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = _changeButtonsColor.BlackMat;
                ButtonsPressed += 1;
                gameObject.GetComponent<ButtonActive>().ButtonIsActive = false;
            }

            if (ButtonsPressed >= 4)
            {
                _snakeSpawner.ThirdWaveBegin = true;
                ButtonsPressed = 0;
                _changeButtonsColor.ColorWaveTwoDone = false;
            }
        }

        if (_changeButtonsColor.ColorWaveThreeDone)
        {
            if (gameObject.CompareTag("BloodyButtons") && gameObject.GetComponent<ButtonActive>().ButtonIsActive == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = _changeButtonsColor.BlackMat;
                ButtonsPressed += 1;
                gameObject.GetComponent<ButtonActive>().ButtonIsActive = false;
            }

            if (ButtonsPressed >= 6)
            {
                HorrorRoomCleard = true;
                ButtonsPressed = 0;
            }
        }
    }
}