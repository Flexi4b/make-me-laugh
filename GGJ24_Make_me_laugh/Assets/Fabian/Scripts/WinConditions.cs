using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{
    void Update()
    {
        PlayerPrefs.GetInt("HorrorClear");
        PlayerPrefs.GetInt("BombaClear");
        PlayerPrefs.GetInt("GrandmaClear");

        if (PlayerPrefs.GetInt("HorrorClear") == 1 && PlayerPrefs.GetInt("BombaClear") == 2 && PlayerPrefs.GetInt("GrandmaClear") == 3)
        {
            PlayerPrefs.SetInt("Victory", 99);
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerPrefs.SetInt("Victory", 2398464);
        }
    }
}
