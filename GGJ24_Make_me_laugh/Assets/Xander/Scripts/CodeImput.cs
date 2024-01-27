using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class CodeImput : MonoBehaviour
{
    private Bombo bombo;
    private RoomMasterScript roomMasterScript;
    private int numbercodeslot0;
    private int numbercodeslot1;
    private int numbercodeslot2;
    private int numbercodeslot3;
    private int numbercodeslot4;
    private int numbercodeslot5;

   [SerializeField] public SpriteRenderer previousSprite;
   [SerializeField] public Sprite newSprite;
   [SerializeField] private TextMeshPro numberslottext0;
   [SerializeField] private TextMeshPro numberslottext1;
   [SerializeField] private TextMeshPro numberslottext2;
   [SerializeField] private TextMeshPro numberslottext3;
   [SerializeField] private TextMeshPro numberslottext4;
   [SerializeField] private TextMeshPro numberslottext5;

    private string correctCode = "661";
    private string inputCodeString;
   [SerializeField] private TextMeshPro inputCode;

    private void Start()
    {
        bombo = FindObjectOfType<Bombo>();
        roomMasterScript = FindObjectOfType<RoomMasterScript>();
        numberslottext3.SetText("0");
        numberslottext4.SetText("0");
        numberslottext5.SetText("0");

        if (correctCode == inputCodeString)
        {
            Debug.Log("worky");
        }
    }

    private void Update()
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
        if (gameObject.CompareTag("ButtonUp1"))
        {
            numbercodeslot3++;
            if (numbercodeslot3 > 9)
            {
                numbercodeslot3 = 0;
            }
            numberslottext3.SetText(numbercodeslot3.ToString());
            Debug.Log(numbercodeslot3);
        }
        if (gameObject.CompareTag("ButtonUp2"))
        {
            numbercodeslot4++;
            if (numbercodeslot4 > 9)
            {
                numbercodeslot4 = 0;
            }
            numberslottext4.SetText(numbercodeslot4.ToString());
        }
        if (gameObject.CompareTag("ButtonUp3"))
        {
            numbercodeslot5++;
            if (numbercodeslot5 > 9)
            {
                numbercodeslot5 = 0;
            }
            numberslottext5.SetText(numbercodeslot5.ToString());
        }

        if (gameObject.CompareTag("ButtonDown1"))
        {
            numbercodeslot3--;
            if (numbercodeslot3 < 0)
            {
                numbercodeslot3 = 9;
            }
            numberslottext3.SetText(numbercodeslot3.ToString()); 
        }
        if (gameObject.CompareTag("ButtonDown2"))
        {
            numbercodeslot4--;
            if (numbercodeslot4 < 0)
            {
                numbercodeslot4 = 9;
            }
            numberslottext4.SetText(numbercodeslot4.ToString());
        }
        if (gameObject.CompareTag("ButtonDown3"))
        {
            numbercodeslot5--;
            if (numbercodeslot5 < 0)
            {
                numbercodeslot5 = 9;
            }
            numberslottext5.SetText(numbercodeslot5.ToString());
        }

        if (gameObject.CompareTag("Verify"))
        {
            inputCode.text += numbercodeslot3.ToString() + numbercodeslot4.ToString() + numbercodeslot5.ToString();
            inputCodeString = inputCode.text.ToString();

                StartCoroutine(CheckCode());
        }
    }

    IEnumerator CheckCode()
    {
        if (inputCodeString == correctCode)
        {
            Debug.Log("CORRECT");
            PlayerPrefs.SetInt("BombaClear", 2);
            previousSprite.sprite = newSprite;
            previousSprite.transform.position = new Vector3(1, 3, (float)23.47);
            bombo._BombHasBeenDefused = true;
            roomMasterScript.room1Clear = true;
        }
        else
        {
            Debug.Log("WRONG");
            inputCode.text = "";
        }
        yield break;
    }
}
