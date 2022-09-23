using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class NPCBase : MonoBehaviourPunCallbacks
{
    public static ExitGames.Client.Photon.Hashtable roomHash;
    private bool NPCinf, cooltime, infected;
    public string Objname,asee;
    public bool NPCinfsee;
    private int infectionProbability=100;
    public  Player player;
    public int a;
    public Infection2 infection2;
    // Start is called before the first frame update
    void Start()
    {
        
        NPCinf = false;
        Objname = this.gameObject.name;
        roomHash = new ExitGames.Client.Photon.Hashtable();
        var byou = GetComponent<itibyou>();

        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }
        Customproperties.NPCcustom(Objname);
        byou.Init(() =>
        {
            NPCinfsee = Customproperties.GetNPCinf(Objname);
            GameObject ds = GameObject.Find("man(Clone)");
            if (ds == null) ds = GameObject.Find("woman(Clone)");
            infection2 = ds.GetComponent<Infection2>();
        });
        byou.Play();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && cooltime == false)
        {
            cooltime = true;
            Invoke(nameof(Cooldowm), 5f);

            infected = Customproperties.GetNPCinf(collision.gameObject.name);
            if (infected == true)
            {
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Invoke(nameof(EffictTime), 180);
                    NPCinf = true;
                    Customproperties.SetNPCinf(Objname, NPCinf);
                }
            }
        }
        if (collision.gameObject.CompareTag("Player") && cooltime == false)
        {
            cooltime = true;
            
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
                    Customproperties.SetNPCinf(Objname, NPCinf);
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
        Customproperties.SetNPCinf(Objname, NPCinf);
    }
}
