using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonsColor : MonoBehaviour
{
    public GameObject[] BloodyButtons;
    public Material[] Materials;

    public Material Black;
    public Material Bloody;
    private List<GameObject> _randomButtons;
    //private List<GameObject> _tempButtons;

    [SerializeField] private bool _snakeWaveOneDone = true;
    [SerializeField] private bool _snakeWaveTwoDone = false;
    [SerializeField] private bool _snakeWaveThreeDone = false;

    public bool ColorWaveOneDone = false;
    public bool ColorWaveTwoDone = false;
    public bool ColorWaveThreeDone = false;

    void Update()
    {
        if (_snakeWaveOneDone == true)
        {
            for (int i = 0; i < 3; i++)
            {
                _randomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                _randomButtons.ToArray();
                _randomButtons[i].GetComponent<ButtonActive>().ButtonIsActive = true;
                //_tempButtons.Add(_randomButtons[i]);
                //_tempButtons.ToArray();
                _randomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }

            //for (int j = 0; j < 3; j++)
            //{
            //    foreach (GameObject gameObject in _randomButtons)
            //    {
            //        if (gameObject == _tempButtons[j])
            //        {
            //            _randomButtons
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //}


            
            _snakeWaveOneDone = false;
            ColorWaveOneDone = true;
        }

        if (_snakeWaveTwoDone && ColorWaveOneDone)
        {
            for (int i = 0; i < 6; i++)
            {
                _randomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                _randomButtons.ToArray();
                _randomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
            _snakeWaveTwoDone = false;
            ColorWaveTwoDone = true;
        }

        if (_snakeWaveThreeDone && ColorWaveTwoDone)
        {
            for (int i = 0; i < 9; i++)
            {
                _randomButtons.Add(BloodyButtons[Random.Range(0, BloodyButtons.Length)]);
                _randomButtons.ToArray();
                _randomButtons[i].GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.Length)];
            }
            _snakeWaveThreeDone = false;
            ColorWaveThreeDone = true;
        }
    }
}
