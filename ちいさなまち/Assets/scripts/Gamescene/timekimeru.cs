using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;

public class Timekimeru : MonoBehaviourPunCallbacks
{
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public  int hour, minite, second;
    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        Array.Sort(player);
        
        var p1 = player[0];

       
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            //var hashtable = new ExitGames.Client.Photon.Hashtable();
            //hashtable["Score"] = 0;
            //hashtable["Message"] = "����ɂ���";
            //PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
            
            var byou = gameObject.AddComponent<itibyou>();
            byou.Init(() =>
            {
                second++;

                if (second == 60) { second = 0; minite++; Customproperties.Setsecond(minite); }
                if (minite == 60) { minite = 0; hour++; Customproperties.Setsecond(hour) ; Customproperties.Setsecond(minite); ; }
                if (hour == 24) { hour = 0; Customproperties.Setsecond(hour); }
                Customproperties.Setsecond(second);
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
            });
            byou.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}