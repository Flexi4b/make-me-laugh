using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 25)
        {
            SceneManager.LoadScene("You Won");
        }
    }

}
