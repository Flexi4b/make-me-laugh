using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 5.5f);        
    }
}
