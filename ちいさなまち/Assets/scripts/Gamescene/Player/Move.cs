using Photon.Pun;
using UnityEngine;
using TMPro;
using Photon.Realtime;

using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class Move : MonoBehaviourPunCallbacks
{
    private bool ispush, ishor, isver, infection, isStart;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y"), myplayernum;
    private Animator animator = null;
    public static Vector3 popo;
    private Vector3 input;
    private Menumanager menumanager;
    private QuestDataBase QuestDataBase;
    public  bool kai,iikai,sugoikai;
    private float speed = 5f;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static string myplayername;
    private Player player;
    private PUN2Server server;
    public Infection2 infection2;
    public void Start()
    {
        GameObject menu = GameObject.Find("PUN2Sever");
        var pun2server = menu.GetComponent<PUN2Server>();
        var playernum = pun2server.playernum;
        
        infection2 = this.gameObject.GetComponent<Infection2>();
        player = PhotonNetwork.LocalPlayer;
        myplayernum = player.ActorNumber;
        myplayername = this.gameObject.name;
        GameObject oya = GameObject.Find("Canvas");
        var player1 = PhotonNetwork.PlayerList;

        animator = GetComponent<Animator>();
        transform.parent = oya.transform;
        if (player1[0] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-3.6f, 10.6f, -1); }
        if (playernum >= 2) if (player1[1] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-1.1f, 10.6f, -1); }
        if (playernum >= 3) if (player1[2] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-16f, 10.6f, -1); }
        if (playernum >= 4) if (player1[3] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-13.5f, 5.7f, -1); }
        if (playernum >= 5) if (player1[4] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-16f, 5.7f, -1); }
        if (playernum >= 6) if (player1[5] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(-13.5f, -1.9f, -1); }
        if (playernum >= 7) if (player1[6] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(16.4f, -1.9f, -1); }
        if (playernum >= 8) if (player1[7] == PhotonNetwork.LocalPlayer) { transform.localPosition = new Vector3(14f, -1.9f, -1); }

    }

    private void Update()
    {
        infection = infection2.GetPlayerinfeffect(myplayernum);

        var menuKey = Menumanager.menuKey;

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        if (infection == true&&!iikai&&!kai&&!sugoikai)
        {
            speed = 1f;
        }
        else if (infection == true && sugoikai)
        {
            speed = 4f;
        }
        else if (infection == true && iikai)
        {
            speed = 3f;
        }
        else if (infection == true && kai)
        {
            speed = 2f;
        }
        if (infection == false)
        {
            speed = 5f;
        }

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

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) { animator.SetFloat(idX, 0.5f); animator.SetFloat(idY, 0); ispush = false; ishor = false; }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { animator.SetFloat(idX, -0.5f); animator.SetFloat(idY, 0); ispush = false; ishor = false; }
                
                if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { animator.SetFloat(idY, 0.5f); animator.SetFloat(idX, 0); ispush = false; isver = false; }
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { animator.SetFloat(idY, -0.5f); animator.SetFloat(idX, 0); ispush = false; isver = false; }
                if (y > 0.1 && ispush == false) { animator.SetFloat(idY, 1); ispush = true; }
                if (y < -0.1 && ispush == false) { animator.SetFloat(idY, -1); ispush = true; }
                if (x > 0.1 && ispush == false) { animator.SetFloat(idX, 1); ispush = true; }
                if (x < -0.1 && ispush == false) { animator.SetFloat(idX, -1); ispush = true; }
            }
           
            popo = transform.position;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shop") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Restranquest.questclear == true)
                {
                    Menumanager.menuKey = "talk";
                }

                else
                {
                    Menumanager.menuKey = "shop";
                }
            }
        }
        if (collision.gameObject.CompareTag("hospitalshop") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Hospitalquest.questclear == true)
                {
                    Menumanager.menuKey = "talk";
                }
                else Menumanager.menuKey = "hospitalshop";
            }
        }
        if (collision.gameObject.CompareTag("drukstore") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Dragstorequest.questclear == true)
                {
                    Menumanager.menuKey = "talk";
                }
                else Menumanager.menuKey = "durkstore";
            }
        }
        if (collision.gameObject.CompareTag("foodstore") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Supermarketquest.questclear == true)
                {
                    Menumanager.menuKey = "talk";
                }
                else Menumanager.menuKey = "foodstore";
            }
        }
        if (collision.gameObject.CompareTag("quest") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                if (Officequest.questclear == true)
                {
                    Menumanager.menuKey = "talk";
                }
                else Menumanager.menuKey = "quest";
            }
        }
        if (collision.gameObject.CompareTag("rule") && photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                Menumanager.menuKey = "rule";
            }
        }
        if (collision.gameObject.CompareTag("hotel") && photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                Menumanager.menuKey = "hotel";
            }
        }

        if (collision.gameObject.CompareTag("reception") && photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter))
            {
                if (QuestDataBase.GetQusetLists()[0].GetIsQuest() == true)
                {
                    Supermarketquest.questclear = true;
                }

                else if (QuestDataBase.GetQusetLists()[1].GetIsQuest() == true)
                {
                    Hospitalquest.questclear = true;
                }

                else if (QuestDataBase.GetQusetLists()[2].GetIsQuest() == true)
                {
                    Dragstorequest.questclear = true;
                }

                else if (QuestDataBase.GetQusetLists()[4].GetIsQuest() == true)
                {
                    Officequest.questclear = true;
                }
            }
        }
    }
}