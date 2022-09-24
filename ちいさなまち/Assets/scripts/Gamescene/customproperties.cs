using ExitGames.Client.Photon;
using Photon.Realtime;
using Unity;
using UnityEngine;
using Photon.Pun;
using System;
using ExitGames.Client.Photon;
using System.Threading.Tasks;

public   class Customproperties :MonoBehaviourPunCallbacks
{
   
    public  ExitGames.Client.Photon.Hashtable roomHash;
    private void Start()
    {
        NPCcustom();
    }

    public  async void NPCcustom()
    {
        await Task.Delay(1000);
        roomHash = new ExitGames.Client.Photon.Hashtable();
        var npcobj = GameObject.FindGameObjectsWithTag("NPC");
        var npcobjnum = GameObject.FindGameObjectsWithTag("NPC").Length;
        foreach (GameObject item in npcobj)
        {
            roomHash.Add($"{item.name}", false);
        }
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);

    }
    //public static bool Getplayerinf(int player)
    //{
    //    return (PhotonNetwork.CurrentRoom.CustomProperties[$"{player}"] is bool inf) ? inf : false;
    //}
    public  bool GetNPCinf(string name)
    {
        return (bool) roomHash[$"{name}"];
    }

    //public static void Setplayerinf( bool inf, int player)
    //{
    //    Debug.Log($"{inf}" + "  " + $"{player}");
    //    PhotonNetwork.CurrentRoom.CustomProperties[$"{player}"] = inf;
        
    //    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    //   roomHash.Clear();
    //}
    
    public  void SetNPCinf(string name,bool inf)
    {
        roomHash[$"{name}"] = inf;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        
        
        
    }
    public  void Show()
    {
        foreach (var prop in roomHash)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}