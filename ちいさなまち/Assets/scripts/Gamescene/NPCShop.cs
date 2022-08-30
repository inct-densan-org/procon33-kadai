using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;


public class NPCShop : MonoBehaviourPunCallbacks
{
    public static ExitGames.Client.Photon.Hashtable roomHash;
    private bool NPCinf, cooltime, infected;
    public string Objname;
    private int infectionProbability;
    public Player player;
    public string a;
    // Start is called before the first frame update
    void Start()
    {
        NPCinf=false;
        Objname = this.gameObject.name;
        roomHash = new ExitGames.Client.Photon.Hashtable();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cooltime = true;
            
            
            Invoke(nameof(Cooldowm), 5f);
            infected = player.GetInfection();
            if (infected == true)
            {
                switch (Objname)
                {
                    case "shopNPC":
                        int rnd = Random.Range(0, 100);
                        if (rnd <= infectionProbability)
                        {
                            Invoke(nameof(EffictTime), 180);
                            NPCinf = true;
                            roomHash["NPC1"] = NPCinf;
                            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                        }
                        break;
                    case "shopNPC2":
                         rnd = Random.Range(0, 100);
                        if (rnd <= infectionProbability)
                        {
                            Invoke(nameof(EffictTime), 180);
                            NPCinf = true;
                            roomHash["NPC2"] = NPCinf;
                            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                        }
                        break;
                    case "shopNPC3":
                         rnd = Random.Range(0, 100);
                        if (rnd <= infectionProbability)
                        {
                            Invoke(nameof(EffictTime), 180);
                            NPCinf = true;
                            roomHash["NPC3"] = NPCinf;
                            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                        }
                        break;
                    case "shopNPC4":
                         rnd = Random.Range(0, 100);
                        if (rnd <= infectionProbability)
                        {
                            Invoke(nameof(EffictTime), 180);
                            NPCinf = true;
                            roomHash["NPC4"] = NPCinf;
                            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                        }
                        break;
                }
               
            }
        }
    }
    void Cooldowm()
    {
        cooltime = false;
    }
    public void localPalyer(Player localplayer)
    {
        player = localplayer;
        a = $"{player}";
    }
    void EffictTime()
    {
        switch (Objname)
        {
            case "shopNPC":
                NPCinf = false;
                roomHash["NPC1"] = NPCinf;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                break;
            case "shopNPC2":
                NPCinf = false;
                roomHash["NPC2"] = NPCinf;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                break;
            case "shopNPC3":
                NPCinf = false;
                roomHash["NPC3"] = NPCinf;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                break;
            case "shopNPC4":
                NPCinf = false;
                roomHash["NPC4"] = NPCinf;
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                break;
        }
    }
}
