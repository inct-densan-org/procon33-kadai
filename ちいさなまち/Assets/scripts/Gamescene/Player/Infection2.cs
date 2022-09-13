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
    public int infectionProbability = 1000;
    private CircleCollider2D collider2;
    public GameObject kansenhani;
    public Shopmanager shopmanager;
    public static bool ismask;
    private NPCBase NPCShop;
    private PUN2Server PUN2Server;
    public  bool infecsee,myinfsee;
    public  int Player;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static bool p1inf, p2inf, p3inf, p4inf, p5inf, p6inf, p7inf, p8inf,myinf;
    // Start is called before the first frame update
    void Start()
    {
        Player = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log(Player);
        collider2 = this.GetComponent<CircleCollider2D>();
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
        myinfsee = GetPlayerinf(Player);
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

        if (collision.gameObject.CompareTag("Player") && photonView.IsMine)// && cooltime == false)
        {
            var playername = collision.gameObject.name;
            cooltime = true;
            Invoke(nameof(Cooldowm), 5f);
            var a = collision.gameObject.GetPhotonView();
            
            var e = a.OwnerActorNr;

            //infected = Customproperties.Getplayerinf(e);
            infected = GetPlayerinf(e);
            if (infected == true )
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                   // await Task.Delay(20000);
                  
                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, true);

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
                    
                    photonView.RPC(nameof(Setplayerinf), RpcTarget.All, Player, true);
                    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                }
            }
        }
        if (collision.gameObject.CompareTag("quest")&&photonView.IsMine)
        {

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {


                Menumanager.menuKey = "quest";
                
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
            Debug.Log("hureta");

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
    public static  bool GetPlayerinf(int number)
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
