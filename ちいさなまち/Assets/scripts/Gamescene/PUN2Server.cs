using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using System.Collections.Generic;
// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PUN2Server : MonoBehaviourPunCallbacks
{
    public static bool isStart,ii;
    public static GameObject clone;
    public GameObject gamestart, wait;
    public TextMeshProUGUI joinnum;
    public static int isman;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static Player localplayer;
    public  bool issee;
    private bool a,b;
    public static int playernum;
    private int f,localplayernum;
    private GameObject[] tagObjects;
    private void Start()
    {
        gamestart.SetActive(false);
        wait.SetActive(true);
        b = true;
        localplayer = PhotonNetwork.LocalPlayer;
        localplayernum = localplayer.ActorNumber;
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];

        isman = Random.Range(0, 2);
        if (isman == 1)
        {
            clone = PhotonNetwork.Instantiate("man", new Vector3(20, 15, -1), Quaternion.identity);
        }
        else
        {
            clone = PhotonNetwork.Instantiate("woman", new Vector3(20, 15, -1), Quaternion.identity);
        }
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            Customproperties.custam();
        }
        Customproperties.mycustom(localplayernum);
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    
    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    
    public void Update()
    {
        issee = isStart;
        tagObjects = GameObject.FindGameObjectsWithTag("Player");
        playernum = tagObjects.Length;
        if (isStart == false&&b==true) 
        {
            joinnum.text = "参加人数　" + $"{playernum}" + "/8　　";
        }
        if (Input.GetKey(KeyCode.Space) && isStart == false && b == true)
        {
            photonView.RPC(nameof(IsStart), RpcTarget.All);
        
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        if (isStart == true && a == false)
        {
            gamestart.SetActive(true);
            wait.SetActive(false);
            a = true;
            clone.SetActive(true);
        
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            var tagObjects = GameObject.FindGameObjectsWithTag("Player").Length;
            // for (int i = 0; i < tagObjects; i++) Debug.Log($"{i + 1}" + ";" + Customproperties.Getplayerinf(i + 1));
            for (int i = 0; i < tagObjects; i++) Debug.Log($"{i + 1}" + ";" + Infection2.GetPlayerinf(i+1));
            var npcobj = GameObject.FindGameObjectsWithTag("NPC");
            var npcobjnum = GameObject.FindGameObjectsWithTag("NPC").Length;
            foreach (GameObject item in npcobj)
            {
                var j = item.name;
                Debug.Log($"{j}" + ";" + Customproperties.GetNPCinf(j));
            }
        }
    }
    
    [PunRPC]
    public void IsStart()
    {
        isStart = true;
    }
}