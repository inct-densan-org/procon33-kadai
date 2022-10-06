using ExitGames.Client.Photon;
using Photon.Realtime;
using Unity;
using UnityEngine;
using Photon.Pun;
using System;
using ExitGames.Client.Photon;
using System.Threading.Tasks;
using System.Collections.Generic;

public   class Customproperties :MonoBehaviourPunCallbacks
{
   
    public  ExitGames.Client.Photon.Hashtable roomHash;
    private GameObject[] npcobj;
    private bool s,q;
   public Dictionary<string, bool> NPCinf = new Dictionary<string, bool>();
    private void Start()
    {
        npcobj = GameObject.FindGameObjectsWithTag("NPC");
        roomHash = new ExitGames.Client.Photon.Hashtable();
    }
   
    public void SEtdifficulty(string difficulty)
    {
        
        roomHash["difficulty"] = difficulty;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    }
    public  void Update()
    {

        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];

        if (p1 == PhotonNetwork.LocalPlayer)
        {
           if (npcobj.Length == 0)
           {
              npcobj = GameObject.FindGameObjectsWithTag("NPC");
           }
           else
           {
             if (s == false)
             {
                s = true;
                
                photonView.RPC(nameof(Setnpc), RpcTarget.All);
             }
           
           }
        }
          
        

    }
  
    [PunRPC]
    void Setnpc()
    {
        q = true;
        npcobj = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject item in npcobj)
        {
            NPCinf.Add($"{item.name}", false);

        }
    }
    public string Getdifficulty()
    {
        return (string)roomHash["difficulty"];
    }
   
    public  bool GetNPCinf(string name)
    {
        if (q) return NPCinf[$"{name}"];
        else return false;


    }

    public  void SetNPCinf(string name,bool inf)
    {
        photonView.RPC(nameof(stn), RpcTarget.All,name,inf);
    }
    [PunRPC]
    void stn(string name, bool inf)
    {
        Debug.Log($"ä¥êıÇµÇΩ{name};{inf}");
        NPCinf[$"{name}"] = inf;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    }
   
     public void ShowCustom()
    {
        foreach (var prop in roomHash)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}