using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse_Movement : MonoBehaviour
{

    void Update()
    {
        OnMouseClick();
    }

    //private void FixedUpdate()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //        Debug.Log(1);
    //        if (hit.collider.gameObject.CompareTag("Door"))
    //        {
    //            Debug.Log(2);
    //        }
    //    }
    //}

    private void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
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
        if (gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
