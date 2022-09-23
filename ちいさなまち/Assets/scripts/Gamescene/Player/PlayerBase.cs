using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private PUN2Server server;
    private bool isStart,a;
    //MOve
    //TimeKimeru
    //Infection2
    //Tile Controller

    // Update is called once per frame
    void Update()
    {
        GameObject menu = GameObject.Find("PUN2Sever");
        var pun2server = menu.GetComponent<PUN2Server>();
        isStart =pun2server.isStart;
        if (isStart == true && a == false)
        {
            a = true;
            gameObject.AddComponent<Move>();
            gameObject.AddComponent<Infection2>();
            
           // gameObject.AddComponent<Timekimeru>();
        }
    }

}
