using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;
using Photon.Realtime;
[RequireComponent(typeof(itibyou))]

public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime ,iti, infected;

    public bool NPCinf;
    private int infectionProbability ;
    public int notmaskinfectionProbability;
    public CircleCollider2D collider2;
    public GameObject kansenhani;
    public Shopmanager shopmanager;
    public  bool ismask;
    private Menumanager menumanager;
    private NPCBase NPCShop;
    private PUN2Server pun2server;
    public  bool infecsee,myinfsee,kanpou,goodkanpou,greatkanpou;
    public  int Player;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public  bool p1inf, p2inf, p3inf, p4inf, p5inf, p6inf, p7inf, p8inf,myinf;
    private Customproperties customproperties;
    // Start is called before the first frame update
    void Start()
    {
        customproperties = GameObject.Find("PUN2Sever").gameObject.GetComponent<Customproperties>();
        GameObject menu = GameObject.Find("PUN2Sever");
         pun2server = menu.GetComponent<PUN2Server>();
        Player = PhotonNetwork.LocalPlayer.ActorNumber;
        menumanager= GameObject.Find("menumanager").gameObject.GetComponent<Menumanager>();
        collider2 = this.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
        var byou = GetComponent<itibyou>();
       // Customproperties.Setplayerinf(false, Player);
        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }
        byou.Init(() =>
        {
           // infecsee = Customproperties.Getplayerinf(Player);

        });
        byou.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(collider2==null) collider2 = this.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
        var myinf = GetPlayerinf(Player);
        var isman = pun2server.isman;
        
        if (myinf == true&&!kanpou&&!goodkanpou&&!greatkanpou)
        {
            
            if (isman == 1) { collider2.radius = 9f; }
            if (isman == 0) { collider2.radius = 5f; }
        }
        else if(myinf&&greatkanpou)
        {
           
            if (isman == 1) { collider2.radius = 6f; }
            if (isman == 0) { collider2.radius = 3.5f; }
        }
        else if (myinf && goodkanpou)
        {
            
            if (isman == 1) { collider2.radius = 7f; }
            if (isman == 0) { collider2.radius = 4f; }
        }
        else if (myinf && kanpou)
        {
            
            if (isman == 1) { collider2.radius = 8f; }
            if (isman == 0) { collider2.radius = 4.5f; }
        }
        if (ismask == true)
        {

            
            infectionProbability = 5;
            
        }
        if (ismask == false)
        {
            infectionProbability = 10;
        }
    }
    
    private async void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && photonView.IsMine)// && cooltime == false)
        {
            var playername = collision.gameObject.name;
            cooltime = true;
            Invoke(nameof(Cooldowm), 5f);
            var a = collision.gameObject.GetPhotonView();
            Debug.Log("hureta");
            var e = a.OwnerActorNr;

            //infected = Customproperties.Getplayerinf(e);
            infected = GetPlayerinf(e);
            if (infected == true &&GetPlayerinf(Player)==false)
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   // await Task.Delay(20000);

                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, true);
                    await Task.Delay(40000);
                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, false);
                }
            }
        }
        if (collision.gameObject.CompareTag("NPC") && photonView.IsMine)
        {
            var NPCname = collision.gameObject.name;

            NPCinf = customproperties.GetNPCinf(NPCname);
            if (NPCinf == true && GetPlayerinf(Player) == false)
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   // await Task.Delay(20000);

                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, true);
                    await Task.Delay(40000);
                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, false);
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
        if (collision.gameObject.CompareTag("kansen")&&photonView.IsMine)
        {

            // await Task.Delay(20000);

           // Customproperties.Setplayerinf(true, Player);
             photonView.RPC(nameof(Setplayerinf), RpcTarget.All,Player,true);
        }
    }
    [PunRPC]
    void Setplayerinf(int number,bool inf)
    {
        switch (number)
        {
            case 1: p1inf = inf; break;
            case 2: p2inf = inf; break;
            case 3: p3inf = inf; break;
            case 4: p4inf = inf; break;
            case 5:p5inf = inf;break;
            case 6:p6inf = inf;break;
            case 7:p7inf = inf;break;
            case 8:p8inf = inf; break;
        }
    }

    //numberに取得したいプレイヤーのIDを渡す
    public   bool GetPlayerinf(int number)
    {

        switch (number)
        {
            case 1:myinf=  p1inf ; break;
            case 2: myinf = p2inf; break;
            case 3: myinf = p3inf; break;
            case 4: myinf = p4inf ; break;
            case 5: myinf = p5inf; break;
            case 6: myinf = p6inf; break;
            case 7: myinf = p7inf; break;
            case 8: myinf = p8inf; break;
        }
        return (myinf);
    }
}
