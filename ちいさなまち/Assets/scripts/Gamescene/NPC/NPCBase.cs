using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Threading.Tasks;

public class NPCBase : MonoBehaviourPunCallbacks
{
    public static ExitGames.Client.Photon.Hashtable roomHash;
    private bool NPCinf, cooltime, infected;
    public string Objname;
    public bool NPCinfsee;
    private int infectionProbability=5;
    public  Player player;
    public int a;
    public Infection2 infection2;
    private Customproperties customproperties;
    private Player p1;
    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        p1 = player[0];
        customproperties = GameObject.Find("PUN2Sever").gameObject.GetComponent<Customproperties>();
        NPCinf = false;
        Objname = this.gameObject.name;
        roomHash = new ExitGames.Client.Photon.Hashtable();
        itibyou();
    }
    async void itibyou()
    {
        NPCinfsee = customproperties.GetNPCinf(Objname);
       

        await Task.Delay(1000);
        itibyou();
    }
    public async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") &&p1 == PhotonNetwork.LocalPlayer )
        {
            

            infected = customproperties.GetNPCinf(collision.gameObject.name);
           
            if (infected == true&&! customproperties.GetNPCinf(gameObject.name))
            {
                
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    
                    NPCinf = true;
                    customproperties.SetNPCinf(Objname, NPCinf);
                    
                    await Task.Delay(100000);
                    customproperties.SetNPCinf(Objname, false);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player")  && !customproperties.GetNPCinf(gameObject.name)&&p1 == PhotonNetwork.LocalPlayer)
        {
          
            GameObject ds = collision.gameObject;
            infection2 = ds.GetComponent<Infection2>();
            var player = collision.gameObject.GetPhotonView();
            var playernum = player.OwnerActorNr;
            a = playernum;
            
            // infected = Customproperties.Getplayerinf(playernum);
            infected = infection2.GetPlayerinf(playernum);
            if (infected == true)
            {
                Debug.Log("hureta");
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   
                    NPCinf = true;
                    customproperties.SetNPCinf(Objname, NPCinf);
                   
                    await Task.Delay(100000);
                    customproperties.SetNPCinf(Objname, false);
                }
            }
        }
    }
    
}
