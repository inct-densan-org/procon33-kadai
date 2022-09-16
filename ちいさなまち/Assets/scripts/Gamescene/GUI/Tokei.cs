using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;
using TMPro;

public  class Tokei : MonoBehaviourPunCallbacks
{
    public int hour, minite, second,time;
    public TextMeshProUGUI text;
    private ExitGames.Client.Photon.Hashtable roomHash;
    //private itibyou byou;
    //private timekimeru timekimeru;
    // Start is called before the first frame update
    void Start()
    {
        var byou = GetComponent<itibyou>();

        if (byou == null)
        {
           byou=  gameObject.AddComponent<itibyou>();
        }
        byou.Init(() =>
        {
            time = Timekimeru.time;
            second = time % 60;
            minite = time / 60;
            if (minite == 60) minite = 0;
            hour = time / 3600;if (hour == 24) hour = 0;
           
        });
        byou.Play();
    }
  
  
    void Update()
    {
        text.text = $"{hour}" + "時間" + $"{minite}" + "分" + $"{second}" + "秒";
    }
    
}
