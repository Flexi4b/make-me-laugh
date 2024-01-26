using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse_Movement : MonoBehaviour
{
    public static Mouse_Movement _mouseMovement;

    private void Start()
    {
        _mouseMovement = this;
    }

    void Update()
    {
        OnMouseClick();
    }

    public void OnMouseClick()
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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (gameObject.CompareTag("NorthDoor"))
            {
                SceneManager.LoadScene(1);
            }
            else if (gameObject.CompareTag("EastDoor"))
            {
                SceneManager.LoadScene(2);
            }
            else if (gameObject.CompareTag("SouthDoor"))
            {
                SceneManager.LoadScene(3);
            }
            else if (gameObject.CompareTag("WestDoor"))
            {
                SceneManager.LoadScene(4);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (gameObject.CompareTag(""))
            {
                //functie met dingen die het moet doen met klik
            }
        }
    }
}
