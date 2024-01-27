using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    private bool ControlsScreen;
    [SerializeField] private GameObject _controlScreen;

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void OpenCredits()
    {
        ControlsScreen = !ControlsScreen;

        if (ControlsScreen) 
        {
            _controlScreen.SetActive(true);
        }
        else
        {
            _controlScreen.SetActive(false);
        }
    }
}
