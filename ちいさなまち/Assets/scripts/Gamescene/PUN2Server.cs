using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PUN2Server : MonoBehaviourPunCallbacks
{
    public  bool isStart, ii;
    public  GameObject clone;
    public GameObject gamestart, wait,OK,rule,ruleicon;
    public TextMeshProUGUI joinnum;
    public  int isman;
    public  ExitGames.Client.Photon.Hashtable roomHash;
    public  Player localplayer;
    public bool issee;
    private bool a, b;
    public  int playernum;
    private int f, localplayernum;
    private GameObject[] tagObjects;
    private Infection2 infection2;
    private Customproperties customproperties;
    private string difficulty;
    private void Start()
    {
        customproperties = this.gameObject.GetComponent<Customproperties>();
        gamestart.SetActive(false);
        wait.SetActive(true);
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("OK", 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        localplayer = PhotonNetwork.LocalPlayer;
        localplayernum = localplayer.ActorNumber;
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer)
        {
            difficulty = Difficulty.difficulty;
            if (difficulty == null) difficulty = "nomal";
            
            customproperties.SEtdifficulty(difficulty);
           
        }
        
            
       
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック

    public void Update()
    {
        if (customproperties.Getdifficulty() == "Null"|| customproperties.Getdifficulty() == null)
        {
            
            difficulty = Difficulty.difficulty;
            if (difficulty == null) difficulty = "nomal";
            customproperties.SEtdifficulty(difficulty);
        }
        
        issee = isStart;
        tagObjects = GameObject.FindGameObjectsWithTag("Player");
        playernum = PhotonNetwork.PlayerList.Length;
        if (isStart == false)
        {

            var player = PhotonNetwork.PlayerList;
          var  p1 = player[0];
            if(p1 == PhotonNetwork.LocalPlayer)
            {
                var w = (int)roomHash["OK"];
                if (w == playernum)
                {
                    photonView.RPC(nameof(playermake), RpcTarget.All);
                    PhotonNetwork.CurrentRoom.IsOpen = false;
                }
            }

            joinnum.text = "参加人数　" + $"{playernum}" + "/8　　";

        }
        //if (Input.GetKey(KeyCode.Space) && isStart == false)
        //{
            
        //    photonView.RPC(nameof(playermake), RpcTarget.All);

        //    PhotonNetwork.CurrentRoom.IsOpen = false;
        //}
        if (isStart == true && a == false)
        {

            gamestart.SetActive(true);
            wait.SetActive(false);
            a = true;
            clone.SetActive(true);
            if (customproperties.Getdifficulty() == "nomal") Moneymanager.Money = 1000;
            if (customproperties.Getdifficulty() == "ez") Moneymanager.Money = 1500;
            if (customproperties.Getdifficulty() == "hard") Moneymanager.Money = 0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            infection2 = tagObjects[0].gameObject.GetComponent<Infection2>();
            var tagObjectsnum = tagObjects.Length;
            // for (int i = 0; i < tagObjects; i++) Debug.Log($"{i + 1}" + ";" + Customproperties.Getplayerinf(i + 1));
            for (int i = 0; i < tagObjectsnum; i++) Debug.Log($"{i + 1}" + ";" + infection2.GetPlayerinf(i + 1));
            var npcobj = GameObject.FindGameObjectsWithTag("NPC");
            var npcobjnum = GameObject.FindGameObjectsWithTag("NPC").Length;
            foreach (GameObject item in npcobj)
            {
                var j = item.name;
                Debug.Log($"{j}" + ";" + customproperties.GetNPCinf(j));
            }

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            customproperties.ShowCustom();
            Debug.Log(customproperties.Getdifficulty());
        }



    }
    public void OnpushOK()
    {
        var a = (int)roomHash["OK"];
        a++;
        roomHash["OK"] = a;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        OK.SetActive(false);
    }
   public void Onpushhihyouzi()
    {
        rule.SetActive(false);
        ruleicon.SetActive(true);
    }
    public void OnPushicon()
    {
        rule.SetActive(true);
        ruleicon.SetActive(false);
    }
    [PunRPC]
    public void playermake()
    {
        isStart = true;
        isman = ClientData.currentCharacter;
        
        if (isman == 0)
        {
            clone = PhotonNetwork.Instantiate("man", new Vector3(20, 15, -1), Quaternion.identity);
        }
        else
        {
            clone = PhotonNetwork.Instantiate("woman", new Vector3(20, 15, -1), Quaternion.identity);
        }
    }
    public override void OnLeftRoom()
    {
        Debug.Log("ルームから退出しました");
        SceneManager.LoadScene("Endscene",LoadSceneMode.Single);
    }
}