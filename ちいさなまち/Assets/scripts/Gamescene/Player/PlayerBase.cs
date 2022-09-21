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
        isStart =PUN2Server.isStart;
        if (isStart == true && a == false)
        {
            a = true;
            gameObject.AddComponent<Move>();
            gameObject.AddComponent<Infection2>();
            gameObject.AddComponent<TileController>();
            gameObject.AddComponent<Timekimeru>();
        }
    }
}
