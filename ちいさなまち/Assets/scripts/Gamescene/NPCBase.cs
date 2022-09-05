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
    public static Player player;
    public static string a;
    // Start is called before the first frame update
    void Start()
    {
        NPCinf=false;
        Objname = this.gameObject.name;
        roomHash = new ExitGames.Client.Photon.Hashtable();
        var byou = gameObject.AddComponent<itibyou>();
        Customproperties.NPCcustom(Objname);
        byou.Init(() =>
        {
            NPCinfsee = Customproperties.GetNPCinf(Objname);
           
        });
        byou.Play();

    }

    // Update is called once per frame
    void Update()
    {
        asee = a;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&cooltime==false)
        {
            cooltime = true;
           
            var player = collision.gameObject.GetPhotonView();
            var playernum = player.OwnerActorNr;
            Invoke(nameof(Cooldowm), 5f);
            infected = Customproperties.Getplayerinf(playernum);
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
