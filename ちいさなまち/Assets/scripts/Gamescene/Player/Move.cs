using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class Move : MonoBehaviourPunCallbacks
{
    private bool ispush,ishor,isver,infection,isStart;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y"),myplayernum;
    private Animator animator = null;
    public static Vector3 popo;
    private Vector3 input;
    private Menumanager menumanager;
    public static bool isdurk;
    private float speed = 5f;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static string myplayername;
    private Player player;
    private PUN2Server server;
    public void Start()
    {
        
      var  playernum = PUN2Server.playernum;
       
        player = PhotonNetwork.LocalPlayer;
        myplayernum = player.ActorNumber;
        myplayername = this.gameObject.name;
        GameObject oya = GameObject.Find("Canvas");
        var player1 = PhotonNetwork.PlayerList;
        
        animator = GetComponent<Animator>();
        transform.parent = oya.transform;
        if (player1[0] == PhotonNetwork.LocalPlayer){ transform.localPosition = new Vector3(0, 5.7f, -1);}
        if(playernum>=2)  if (player1[1] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(2, 5.7f, -1); }
        if (playernum >= 3) if (player1[2] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(4, 5.7f, -1); }
        if (playernum >= 4) if (player1[3] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(6, 5.7f, -1); }
        if (playernum >= 5) if (player1[4] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(8, 5.7f, -1); }
        if (playernum >= 6) if (player1[5] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(10, 5.7f, -1); }
        if(playernum>=7)   if (player1[6] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(6, 5.7f, -1); }
        if (playernum >= 8) if (player1[7] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(7, 5.7f, -1); }

        var byou = GetComponent<itibyou>();

        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }

        if (byou == null)
        {
            gameObject.AddComponent<itibyou>();
        }
        byou.Init(() =>
        {
         
           // infection = Customproperties.Getplayerinf(player.ActorNumber);
        });
        byou.Play();

    }

    private void Update()
    {
        infection = Infection2.GetPlayerinf(myplayernum);
        //var isshop = shopmanager.isshop;
        var menuKey = Menumanager.menuKey;
        
        var x = Input.GetAxisRaw("Horizontal");
        var  y = Input.GetAxisRaw("Vertical");
        //if (infection == true&&isdurk==false)
        //{
        //    speed = 1f;
        //}
        //if (infection == true && isdurk == true)
        //{
        //    speed = 3f;
        //}
        //if(infection==false)
        //{
        //    speed = 5f;
        //}デバッグのために外します
        
        if (photonView.IsMine)
        {
            if (menuKey == null)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 && isver == false)
                {
                    input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0f); ishor = true;
                }
                else if (Input.GetAxisRaw("Vertical") != 0 && ishor == false)
                {
                    input = new Vector3(0, Input.GetAxisRaw("Vertical"), 0f); isver = true;
                }
                else
                {
                    input = new Vector3(0, 0, 0f);
                }
                transform.Translate(speed * Time.deltaTime * input.normalized);
            } 
            
            popo = transform.position;
            if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.RightArrow)){ animator.SetFloat(idX, 0.5f); animator.SetFloat(idY, 0); ispush = false; ishor = false; }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { animator.SetFloat(idX, -0.5f); animator.SetFloat(idY, 0); ispush=false; ishor = false; }
            if (x > 0.1 && ispush == false) { animator.SetFloat(idX, 1); ispush = true; }
            if (x <-0.1 && ispush == false) { animator.SetFloat(idX, -1); ispush = true; }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { animator.SetFloat(idY, 0.5f); animator.SetFloat(idX, 0); ispush = false; isver = false;  }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { animator.SetFloat(idY, -0.5f); animator.SetFloat(idX, 0); ispush = false;isver = false; }
            if (y > 0.1 && ispush == false) { animator.SetFloat(idY, 1); ispush = true; }
            if (y < -0.1 && ispush == false) { animator.SetFloat(idY, -1); ispush = true; }
        }
    }
    public static void Effecttime()
    {

        isdurk = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shop") && photonView.IsMine)
        {
            
            if (Input.GetKey(KeyCode.Space))
            {


                Menumanager.menuKey = "shop";
                
                
            }
        }
        if (collision.gameObject.CompareTag("quest") && photonView.IsMine)
        {
           
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {


                Menumanager.menuKey = "quest";

            }
        }
    }
}

