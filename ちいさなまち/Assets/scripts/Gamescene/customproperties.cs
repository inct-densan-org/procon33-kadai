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
    private GameObject[] npcobj;
    private bool s;
    private void Start()
    {
        npcobj = GameObject.FindGameObjectsWithTag("NPC");
        roomHash = new ExitGames.Client.Photon.Hashtable();
    }

    public  void Update()
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
                SEtNPCcustom();
            }
           
        }
        

    }
   async void SEtNPCcustom()
    {
        await Task.Delay(1000);
        npcobj = GameObject.FindGameObjectsWithTag("NPC");
        var npcobjnum = GameObject.FindGameObjectsWithTag("NPC").Length;
        foreach (GameObject item in npcobj)
        {
            roomHash.Add($"{item.name}", false);
            
        }
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
    }
    public  bool GetNPCinf(string name)
    {
        
        return (bool) roomHash[$"{name}"];
    }

    public  void SetNPCinf(string name,bool inf)
    {
        roomHash[$"{name}"] = inf;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        
        
        
    }
    
}