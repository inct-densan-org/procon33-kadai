using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoomWindow : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenWindow(){
        gameObject.SetActive(true);
    }

    public void CloseWindow(){
        gameObject.SetActive(false);
    }
}
