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
    //ExitGames.Client.Photon.Hashtable roomHash;
    //private itibyou byou;
    //private timekimeru timekimeru;
    // Start is called before the first frame update
    void Start()
    {
        //var roomHash = timekimeru.roomHash;

        // //var player = PhotonNetwork.PlayerList;
        // //Array.Sort(player);
        // // p1 = player[0];


        //text = GetComponent<TextMeshPro>();

        // byou = gameObject.AddComponent<itibyou>();


        //byou.Init(() =>
        //{
        //    hour = (int)roomHash["hour"];
        //    minite = (int)roomHash["minite"];
        //    second = (int)roomHash["second"];
        //    // hour = p1.Gethour();
        //    //  minite = p1.Getminute();
        //    //second = p1.GetScond();

        //});
        //byou.Play();

        //hour = 6;
        //if (PhotonNetwork.IsMasterClient)
        //{


        //    //var hashtable = new ExitGames.Client.Photon.Hashtable();
        //    //hashtable["Score"] = 0;
        //    //hashtable["Message"] = "こんにちは";
        //    //PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);

        //    var byou = gameObject.AddComponent<itibyou>();
        //    byou.Init(() =>
        //    {


        //        second++;

        //        if (second == 60) { second = 0; minite++; PhotonNetwork.LocalPlayer.Addminute(minite); }
        //        if (minite == 60) { minite = 0; hour++; PhotonNetwork.LocalPlayer.Addhour(hour); PhotonNetwork.LocalPlayer.Addminute(minite); }
        //        if (hour == 24) { hour = 0; PhotonNetwork.LocalPlayer.Addhour(hour); }
        //        PhotonNetwork.LocalPlayer.Addsecond(second);
        //        text.text = $"{hour}" + "時" + $"{minite}" + "分" + $"{second}" + "秒";
        //    });
        //    byou.Play();
        //}
    }
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        object value = null;
        //変更のあったプロパティに"Time"が含まれているならtimeを更新
        if (propertiesThatChanged.TryGetValue("hour", out value))
        {
            hour = (int)value;
        }
        if (propertiesThatChanged.TryGetValue("minite", out value))
        {
            minite = (int)value;
        }
        if (propertiesThatChanged.TryGetValue("second", out value))
        {
            second = (int)value;
        }
    }
    //public   int GetScore(this Player player)
    // {
    //   return (player.CustomProperties[second] is int score) ? score : 0;
    // }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{hour}" + "時" + $"{minite}" + "分" + $"{second}" + "秒";
    }
    
}
