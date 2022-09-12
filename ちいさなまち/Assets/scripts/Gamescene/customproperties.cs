using ExitGames.Client.Photon;
using Photon.Realtime;
using Unity;
using UnityEngine;
using Photon.Pun;
using System;
using ExitGames.Client.Photon;
public  static class Customproperties 
{
    public static int hour, minite, second;
    public static ExitGames.Client.Photon.Hashtable roomHash;

    public static void custam()
    {

        
        var a = false;
        roomHash = new ExitGames.Client.Photon.Hashtable
        {
            //{ "hour", hour },
            //{ "minite", minite },
            { "Time", second },
           


        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    }
    
    public static void mycustom(int player)
    {
       
        roomHash.Add($"{player}", false);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    }
    public static void NPCcustom(string NPC)
    {

        roomHash.Add($"{NPC}", false);
        
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    }
   
    public static int GetTime()
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties["Time"] is int second) ? second : 0;
    }
   
    public static bool Getplayerinf(int player)
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties[$"{player}"] is bool inf) ? inf : false;
    }
    public static bool GetNPCinf(string name)
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties[$"{name}"] is bool inf) ? inf : false;
    }

    public static void Setplayerinf( bool inf, int player)
    {
        PhotonNetwork.CurrentRoom.CustomProperties[$"{player}"] = inf;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        roomHash.Clear();
    }
   
    
    public static void SetNPCinf(string name,bool inf)
    {
        PhotonNetwork.CurrentRoom.CustomProperties[$"{name}"] = inf;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        roomHash.Clear();
    }
  
}
   

