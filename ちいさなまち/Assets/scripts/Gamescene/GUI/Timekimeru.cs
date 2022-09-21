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
    public  int hour, minite, second,time1;
    public static int time;
    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            
            var byou = GetComponent<itibyou>();

            if (byou == null)
            {
                byou = gameObject.AddComponent<itibyou>();
            }
            byou.Init(() =>
            {
                time1++;

                photonView.RPC(nameof(SetTime), RpcTarget.All, time1);
            });
            byou.Play();
        }
    }
    [PunRPC]
    public void SetTime(int second)
    {
        time = second;
    }
}