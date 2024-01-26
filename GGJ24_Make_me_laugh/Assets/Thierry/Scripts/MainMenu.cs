using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     //Play music?   
    }
    public void Quit()
    {
        //Quits the program upon pressing the "Quit" Button
        Application.Quit();
        Debug.Log("Application has quit");
    }
    public void Start(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene should be loading");
    }
}
