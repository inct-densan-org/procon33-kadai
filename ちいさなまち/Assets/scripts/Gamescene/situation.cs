using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class situation : MonoBehaviour
{ 
    public GameObject text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            text.SetActive(true);
        }
    }
}
