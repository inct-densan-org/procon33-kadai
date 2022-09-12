using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using Photon.Realtime;
[RequireComponent(typeof(itibyou))]

public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime ,iti;
    public  bool infected;
    public bool NPCinf;
    public int infectionProbability = 1000;
    private CircleCollider2D collider2;
    public GameObject kansenhani;
    public Shopmanager shopmanager;
    public static bool ismask;
    private NPCBase NPCShop;
    private PUN2Server PUN2Server;
    public  bool infecsee;
    public static int Player;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    // Start is called before the first frame update
    void Start()
    {
        var a = this.gameObject.GetPhotonView();
        Player = a.OwnerActorNr;
        Debug.Log(Player);
        collider2 = this.GetComponent<CircleCollider2D>();
        var byou = GetComponent<itibyou>();

        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }
        byou.Init(() =>
        {
            infecsee = Customproperties.Getplayerinf(Player);

        });
        byou.Play();

    }

    // Update is called once per frame
    void Update()
    {
       
        var isman = PUN2Server.isman;
        
        if (infected == true)
        {
            if (isman == 1) { collider2.radius = 9f; }
            if (isman == 0) { collider2.radius = 5f; }
        }
        else
        {
            if (isman == 1) { collider2.radius = 6f; }
            if (isman == 0) { collider2.radius = 3.5f; }
        }
        if (ismask == true&&iti==false)
        {
            
            iti = true;
            infectionProbability = 1;
            Invoke(nameof(Effecttime), 10);
        }
        if (ismask == false)
        {
            infectionProbability = 100;
        }
    }
    void Effecttime()
    {
        iti = false; ismask = false;
    }
    private async void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") )// && cooltime == false)
        {
            var playername = collision.gameObject.name;
            cooltime = true;
            Invoke(nameof(Cooldowm), 5f);
            var a = collision.gameObject.GetPhotonView();
            
            var e = a.OwnerActorNr;
           
            infected = Customproperties.Getplayerinf(e);
            
            if (infected == true )
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   // await Task.Delay(20000);
                  var myinfected = true;
                    Customproperties.Setplayerinf(myinfected, Player);
                   
                }
            }
        }
        if (collision.gameObject.CompareTag("NPC") && photonView.IsMine)
        {
            var NPCname = collision.gameObject.name;
            
            NPCinf = Customproperties.GetNPCinf(NPCname);
            if (NPCinf == true)
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   // await Task.Delay(20000);
                    var myinf = true;
                    Customproperties.Setplayerinf(myinf, Player);
                    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                }
            }
        }

    }

    void Cooldowm()
    {
        cooltime = false;
    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kansen"))
        {
            var myplayername =this.gameObject.name;
           // await Task.Delay(20000);
            infected = true;
            Customproperties.Setplayerinf(infected, Player);
           // photonView.RPC(nameof(dede), RpcTarget.All);
        }
    }
    [PunRPC]
    void dede()
    {
        Debug.Log(Player);
    }
}
