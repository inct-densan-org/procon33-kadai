using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
public class itibyou : MonoBehaviourPunCallbacks
{
    private Action executeAction;
    private bool executeFlag = false;

    public int elapsedTime = 0;
    private float intervalTime = 0;

    public int back = 0;
    private void Start()
    {
        elapsedTime= PhotonNetwork.ServerTimestamp;
        back = elapsedTime;
    }
    private void Update()
    {
        if (executeAction != null && executeFlag)
        {
            elapsedTime = PhotonNetwork.ServerTimestamp;
            //elapsedTime += Time.deltaTime;
            
            if (elapsedTime - back >= 1000)
            {
                back = elapsedTime;
                executeAction();

            }
            if(elapsedTime < back)
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
//一秒ごとに何かしたいときは他のスクリプトで以下のようにする。これは例である。一秒ごとにデバッグログに秒数を書くようにしている
//private float time = 0;
//private itibyou byou;
// 
//void Start()
//{
//    
//    var byou = gameObject.AddComponent<itibyou>();
//    byou.Init(() =>
//    {

//        time++;
//        Debug.Log(time);
//    });
//    byou.Play();
//}
//Play（）でスタート　Stop（）で止める

