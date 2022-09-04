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
        var g = PhotonNetwork.LocalPlayer;
       
        var a = false;
        roomHash = new ExitGames.Client.Photon.Hashtable
        {
            { "hour", hour },
            { "minite", minite },
            { "second", second },
            { "shopNPC", a },
            { "NPC2", a },//NPC‚Ì–¼‘O‚Æ“¯‚¶‚É‚·‚é‚±‚Æ

            { "NPC3", a },//NPC‚Ì–¼‘O‚Æ“¯‚¶‚É‚·‚é‚±‚Æ
            { "NPC4", a },//NPC‚Ì–¼‘O‚Æ“¯‚¶‚É‚·‚é‚±‚Æ
            
            
        };
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    }
    public static void mycustom(int player)
    {
       
        roomHash.Add($"{player}", false);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    }
    public static int Getsecond()
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties["second"] is int second) ? second : 0;
    }
    public static int Getminute()
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties["minite"] is int time) ? time : 0;
    }
    public static int Gethour()
    {
        return (PhotonNetwork.CurrentRoom.CustomProperties["hour"] is int inf) ? inf : 0;
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
    public static void Setsecond(int time)
    {
        PhotonNetwork.CurrentRoom.CustomProperties["second"] = time;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        roomHash.Clear();
    }
    public static void Sethour(int time)
    {
        PhotonNetwork.CurrentRoom.CustomProperties["hour"] = time;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        roomHash.Clear();
    }
    public static void Setminute(int time)
    {
        PhotonNetwork.CurrentRoom.CustomProperties["minite"] = time;
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
   

