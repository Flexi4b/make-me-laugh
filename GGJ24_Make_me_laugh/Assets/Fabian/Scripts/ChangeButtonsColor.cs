using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonsColor : MonoBehaviour
{
    public GameObject[] BloodyButtons;
    public Material[] Materials;
    public List<GameObject> RandomButtons;

    public bool _snakeWaveOneDone = false;
    public bool _snakeWaveTwoDone = false;
    public bool _snakeWaveThreeDone = false;

    public bool ColorWaveOneDone = false;
    public bool ColorWaveTwoDone = false;
    public bool ColorWaveThreeDone = false;

    public Material BlackMat;
    public Material BloodyMat;

    private HorrorRoomMouseMove HRMM;
    private SnakeSpawner _snakeSpawner;

    private void Start()
    {
        HRMM = FindObjectOfType<HorrorRoomMouseMove>();
        _snakeSpawner = FindObjectOfType<SnakeSpawner>();
    }

    void Update()
    {
        if (_snakeWaveOneDone)
        {
            for (int i = 0; i < 3; i++)
            {
                RandomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                RandomButtons.ToArray();
                RandomButtons[i].GetComponent<ButtonActive>().ButtonIsActive = true;
                RandomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }

            _snakeWaveOneDone = false;
            ColorWaveOneDone = true;
        }

        if (_snakeWaveTwoDone)
        {
            //for (int i = 0; i < BloodyButtons.Length; i++)
            //{
            //    BloodyButtons[i].GetComponent<MeshRenderer>().material = BloodyMat;
            //}
            for (int i = 0; i < 6; i++)
            {
                RandomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                RandomButtons.ToArray();
                RandomButtons[i].GetComponent<ButtonActive>().ButtonIsActive = true;
                RandomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }

            _snakeWaveTwoDone = false;
            ColorWaveTwoDone = true;
        }

        if (_snakeWaveThreeDone)
        {
            for (int i = 0; i < BloodyButtons.Length; i++)
            {
                BloodyButtons[i].GetComponent<MeshRenderer>().material = BloodyMat;
            }

            for (int i = 0; i < 9; i++)
            {
                RandomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                RandomButtons.ToArray();
                RandomButtons[i].GetComponent<ButtonActive>().ButtonIsActive = true;
                RandomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
            
            _snakeWaveThreeDone = false;
            ColorWaveThreeDone = true;
        }
    }
}
