using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System;

public class timekimeru : MonoBehaviourPunCallbacks
{
   public static ExitGames.Client.Photon.Hashtable roomHash;
    public  int hour, minite, second;
    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        Array.Sort(player);
        
        var p1 = player[0];
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("hour", hour);
        roomHash.Add("minite", minite);
        roomHash.Add("second", second);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        if (p1==PhotonNetwork.LocalPlayer)
        {
           
            
            //var hashtable = new ExitGames.Client.Photon.Hashtable();
            //hashtable["Score"] = 0;
            //hashtable["Message"] = "‚±‚ñ‚É‚¿‚Í";
            //PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);

            var byou = gameObject.AddComponent<itibyou>();
            byou.Init(() =>
            {


                second++;

                if (second == 60) { second = 0; minite++; roomHash["minite"]=minite; }
                if (minite == 60) { minite = 0; hour++; roomHash["hour"]=hour; roomHash["minite"] = minite; }
                if (hour == 24) { hour = 0; roomHash["hour"] = hour; }
                roomHash["second"] = second;
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
