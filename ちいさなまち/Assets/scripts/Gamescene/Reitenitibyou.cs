using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
public class Reitenitibyou : MonoBehaviourPunCallbacks
{
    private Action executeAction;
    private bool executeFlag = false;

    public int elapsedTime = 0;
    private float intervalTime = 0;

    public int back = 0;
    private void Start()
    {
        elapsedTime = PhotonNetwork.ServerTimestamp;
        back = elapsedTime;
    }
    private void Update()
    {
        if (executeAction != null && executeFlag)
        {
            elapsedTime = PhotonNetwork.ServerTimestamp;
            //elapsedTime += Time.deltaTime;

            if (elapsedTime - back >= 100)
            {
                back = elapsedTime;
                executeAction();
            }
            if (elapsedTime < back)
            {
                back = elapsedTime;
            }
        }
    }

    public void Init(Action action, float intervalTime = 1f)
    {
        this.executeAction = action;
        this.intervalTime = intervalTime;
    }

    public void Play()
    {
        executeFlag = true;
    }

    public void Stop()
    {
        executeFlag = false;
    }
}
