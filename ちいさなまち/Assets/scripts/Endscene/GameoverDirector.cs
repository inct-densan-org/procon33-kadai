using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverDirector : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
     if(Input.GetmouseButtonDown(0))
        {
            SceneManager.LoadScene("StartGame");
        }
    }
}
