using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse_Movement : MonoBehaviour
{
    private Trow_Ball _trowBall;

    private void Start()
    {
        _trowBall = FindObjectOfType<Trow_Ball>();
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
            if (gameObject.CompareTag("Obstacle"))
            {
                _trowBall.GoBall();
            }
        }
    }
}
