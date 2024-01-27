using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse_Movement : MonoBehaviour
{
    private RoomMasterScript roomMasterScript;
    public int keysCollected = 0;
    void Update()
    {
        OnMouseClick();
    }
    private void Start()
    {
        roomMasterScript = FindObjectOfType<RoomMasterScript>();
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (gameObject.CompareTag("NorthDoor"))
            {
             
            SceneManager.LoadScene(2);
                
            }
            else if (gameObject.CompareTag("EastDoor"))
            {
                SceneManager.LoadScene(3);
            }
            else if (gameObject.CompareTag("SouthDoor"))
            {
                SceneManager.LoadScene(5);
            }
            else if (gameObject.CompareTag("WestDoor"))
            {
                SceneManager.LoadScene(4);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (gameObject.CompareTag("SouthDoor"))
            {
                SceneManager.LoadScene(1);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (gameObject.CompareTag("NorthDoor"))
            {
                SceneManager.LoadScene(1);
            }
        }
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                if (gameObject.CompareTag("ChefsKnife"))
                {
                    keysCollected++;
                    Destroy(gameObject);
                    if (keysCollected >= 3)
                    {
                        roomMasterScript.room2Clear = true;
                    }
                }

                if (gameObject.CompareTag("NorthDoor"))
                {
                    SceneManager.LoadScene(1);
                }
            }
                
        }
    }
}
