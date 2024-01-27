using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    public GameObject SnakePrefab;

    public GameObject[] SpawnpointSnake;

    public bool FirstWaveBegin = true;
    public bool SecondWaveBegin = false;
    public bool ThirdWaveBegin = false;

    private ChangeButtonsColor _changeButtonsColor;
    private HorrorRoomMouseMove HRMM;

    void Start()
    {
        _changeButtonsColor = FindObjectOfType<ChangeButtonsColor>();
        HRMM = FindObjectOfType<HorrorRoomMouseMove>();
    }

    void Update()
    {
        if (FirstWaveBegin)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(SnakePrefab, SpawnpointSnake[Random.Range(0, SpawnpointSnake.Length)].transform.position, SpawnpointSnake[i].transform.rotation);
            }

            FirstWaveBegin = false;
        }

        if (HRMM.FirstWaveSnakesDestroyed == 3)
        {
            _changeButtonsColor._snakeWaveOneDone = true;
            HRMM.FirstWaveSnakesDestroyed = -20;
        }

        if (SecondWaveBegin)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(SnakePrefab, SpawnpointSnake[Random.Range(0, SpawnpointSnake.Length)].transform.position, SpawnpointSnake[i].transform.rotation);
            }

            SecondWaveBegin = false;
        }

        if (HRMM.SecondWaveSnakesDestroyed == 8)
        {
            _changeButtonsColor._snakeWaveTwoDone = true;
            HRMM.SecondWaveSnakesDestroyed = -20;
        }

        if (ThirdWaveBegin)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(SnakePrefab, SpawnpointSnake[Random.Range(0, SpawnpointSnake.Length)].transform.position, SpawnpointSnake[i].transform.rotation);
            }

            ThirdWaveBegin = false;
        }

        if (HRMM.ThirdWaveSnakesDestroyed == 16)
        {
            _changeButtonsColor._snakeWaveThreeDone = true;
            HRMM.ThirdWaveSnakesDestroyed = -20;
        }
    }
}
