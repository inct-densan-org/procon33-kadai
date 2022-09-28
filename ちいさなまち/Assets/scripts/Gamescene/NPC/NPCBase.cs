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
    public string Objname,asee;
    public bool NPCinfsee;
    private int infectionProbability=5;
    public  Player player;
    public int a;
    public Infection2 infection2;
    private Customproperties customproperties;
    // Start is called before the first frame update
    void Start()
    {
        customproperties = GameObject.Find("PUN2Sever").gameObject.GetComponent<Customproperties>();
        NPCinf = false;
        Objname = this.gameObject.name;
        roomHash = new ExitGames.Client.Photon.Hashtable();
        var byou = GetComponent<itibyou>();

        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }
        
        byou.Init(() =>
        {
            NPCinfsee = customproperties.GetNPCinf(Objname);
            
           
        });
        byou.Play();
    }

    public async void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && cooltime == false)
        {
            cooltime = true;
            Invoke(nameof(Cooldowm), 5f);

            infected = customproperties.GetNPCinf(collision.gameObject.name);
            if (infected == true&& customproperties.GetNPCinf(gameObject.name))
            {
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Invoke(nameof(EffictTime), 180);
                    NPCinf = true;
                    customproperties.SetNPCinf(Objname, NPCinf);
                    await Task.Delay(100000);
                    customproperties.SetNPCinf(Objname, false);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player") && cooltime == false && customproperties.GetNPCinf(gameObject.name))
        {
            cooltime = true;
            GameObject ds = collision.gameObject;
            infection2 = ds.GetComponent<Infection2>();
            var player = collision.gameObject.GetPhotonView();
            var playernum = player.OwnerActorNr;
            a = playernum;
            Invoke(nameof(Cooldowm), 5f);
            // infected = Customproperties.Getplayerinf(playernum);
            infected = infection2.GetPlayerinf(playernum);
            if (infected == true)
            {
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Invoke(nameof(EffictTime), 180);
                    NPCinf = true;
                    customproperties.SetNPCinf(Objname, NPCinf);
                    await Task.Delay(100000);
                    customproperties.SetNPCinf(Objname, false);
                }
            }
        }
    }
    void Cooldowm()
    {
        cooltime = false;
    }

    void EffictTime()
    {
        NPCinf = false;
        customproperties.SetNPCinf(Objname, NPCinf);
    }
}
