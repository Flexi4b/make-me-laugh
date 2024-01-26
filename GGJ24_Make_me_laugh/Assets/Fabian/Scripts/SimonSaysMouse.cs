using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonSaysMouse : MonoBehaviour
{
    private ChangeButtonsColor _changeButtonsColor;

    void Start()
    {
        _changeButtonsColor = FindObjectOfType<ChangeButtonsColor>();
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
        if (_changeButtonsColor.ColorWaveOneDone == false)
        {
            if (gameObject.CompareTag("BloodyButtons") && gameObject.GetComponent<ButtonActive>().ButtonIsActive == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = _changeButtonsColor.Black;
                
            }

            gameObject.GetComponent<ButtonActive>().ButtonIsActive = false;
        }
    }
}