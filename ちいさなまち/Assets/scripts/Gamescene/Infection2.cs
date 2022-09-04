using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using Photon.Realtime;

public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime ,iti;
    public static bool infected;
    public bool NPCinf;
    public int infectionProbability = 1000;
    private CircleCollider2D collider2;
    public GameObject kansenhani;
    public Shopmanager shopmanager;
    public static bool ismask;
    private NPCBase NPCShop;
    private PUN2Server PUN2Server;
    public bool infecsee;
    private int Player;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    // Start is called before the first frame update
    void Start()
    {
        var a = this.gameObject.GetPhotonView();
        Player = a.OwnerActorNr;
        //kansenhani = transform.Find("kansenhani").gameObject;
        collider2 = this.GetComponent<CircleCollider2D>();

        //var byou = gameObject.AddComponent<itibyou>();
        //byou.Init(() =>
        //{
            
        //    //var a = PhotonNetwork.PlayerList;
        //    //var b = a[0];
        //    //var c = a[1];
        //    //if (b != null && c != null)
        //    //{
        //    //    if (b.GetInfection() != c.GetInfection()) Debug.Log("dayone");
        //    //}
        //});
        //byou.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
        var isman = PUN2Server.isman;
        infecsee = Customproperties.Getplayerinf(Player);
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
            infectionProbability = 5;
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
            Debug.Log(infected);
            if (infected == true )//infected�͓������Ȃ��Ƃ����Ȃ�
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
            if (NPCinf == true)//infected�͓������Ȃ��Ƃ����Ȃ�
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
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        NPCShop.localPalyer(null);
    //    }
    //}

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
