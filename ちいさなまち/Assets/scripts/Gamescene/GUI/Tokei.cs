using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public  class Tokei : MonoBehaviourPunCallbacks
{
    public int hour, minite, second,time;
    public TextMeshProUGUI text;
    
    private ExitGames.Client.Photon.Hashtable roomHash;
    private Timekimeru timekimeru;
    private GameObject menumanager;
    void Start()
    {
        time = 600;
        
        menumanager = GameObject.Find("menumaneger");
        timekimeru = menumanager.GetComponent<Timekimeru>();
        
    }
    void Update()
    {
        time = timekimeru.time;
        second = time % 60;
        minite = time / 60;
        if (minite == 60) minite = 0;
        hour = time / 3600; if (hour == 24) hour = 0;
        text.text =   $"{minite}" + ":" + $"{second}" ;
    }
}
