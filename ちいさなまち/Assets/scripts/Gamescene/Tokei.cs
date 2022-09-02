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
    private int hour, minite, second;
    public TextMeshProUGUI text;
    private ExitGames.Client.Photon.Hashtable roomHash;
    //private itibyou byou;
    //private timekimeru timekimeru;
    // Start is called before the first frame update
    void Start()
    {
        var byou = gameObject.AddComponent<itibyou>();
        byou.Init(() =>
        {
            hour = Customproperties.Gethour();
            second = Customproperties.Getsecond();
            minite = Customproperties.Getminute();
        });
        byou.Play();
    }
  
  
    void Update()
    {
        text.text = $"{hour}" + "時間" + $"{minite}" + "分" + $"{second}" + "秒";
    }
    
}
