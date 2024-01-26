using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpigotGame : MonoBehaviour
{
    [SerializeField] private bool[] _notch;
    [SerializeField] private SpriteRenderer[] _spigotSprites;

    [SerializeField] private Sprite _numberToReplace;
    [SerializeField] private SpriteRenderer _numberShower;


    private bool PuzzleSolved;

    // The singular color i had to add myself

    private Color pink = new Color(255, 79, 255);

    void Start()
    {
        _spigotSprites[1].color = Color.green;
    }


    void Update()
    {

        OnMouseClick();
        SpigotSolutions();

        for (int i = 0; i < _spigotSprites.Length; i++)
        {
            if (_notch[i] == false)
            {
                _spigotSprites[i].color = Color.magenta;
            }
            else if (_notch[i] == true)
            {
                _spigotSprites[i].color = Color.green;
            }
        }

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
                    OnHitSpigot(hit.transform.gameObject);
                }
                else
                {

                }
            }
        }
    }

    private void OnHitSpigot(GameObject hitSpiggot)
    {
        /*
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {  THE CORRECT BUILDINDEX HAS TO GO HERE
        */

            if (hitSpiggot.CompareTag("Spigot0"))
            {
                _notch[0] = !_notch[0];
            }
        
            if (hitSpiggot.CompareTag("Spigot1"))
            {
                _notch[1] = !_notch[1];
            }
            if (hitSpiggot.CompareTag("Spigot2"))
            {
                _notch[2] = !_notch[2];
            }
            if (hitSpiggot.CompareTag("Spigot3"))
            {
                _notch[3] = !_notch[3];
            }
            if (hitSpiggot.CompareTag("Spigot4"))
            {
                _notch[4] = !_notch[4];
            }
            if (hitSpiggot.CompareTag("Spigot5"))
            {
                _notch[5] = !_notch[5];
            }
    }

    private void SpigotSolutions()
    {
         if (_notch[0] == true && _notch[1] == true && _notch[2] == true && _notch[3] == false && _notch[4] == true && _notch[5] == false)
        {
            StartCoroutine(FinishSpigot());
        }

    }

    private IEnumerator FinishSpigot()
    {
        _numberShower.sprite = _numberToReplace;
        yield break;
    }
}
