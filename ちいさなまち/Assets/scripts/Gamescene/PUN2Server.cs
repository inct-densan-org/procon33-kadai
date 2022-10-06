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
    private bool a, b,c,q;
    public  int playernum,s;
    private int f, localplayernum;
    private GameObject[] tagObjects;
    private Infection2 infection2;
    private Customproperties customproperties;
    public  string difficulty;
    private Player p1;
    private bool p1ok, p2ok, p3ok, p4ok, p5ok, p6ok, p7ok, p8ok;
  
    private void Start()
    {
        customproperties = this.gameObject.GetComponent<Customproperties>();
        gamestart.SetActive(false);
        wait.SetActive(true);
        roomHash = new ExitGames.Client.Photon.Hashtable();
        
       
        localplayer = PhotonNetwork.LocalPlayer;
        localplayernum = localplayer.ActorNumber;
        var player = PhotonNetwork.PlayerList;
         p1 = player[0];
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
        if (customproperties.Getdifficulty() == "Null" && p1 == PhotonNetwork.LocalPlayer || customproperties.Getdifficulty() == null && p1 == PhotonNetwork.LocalPlayer)
        {

            difficulty = Difficulty.difficulty;
            if (difficulty == null) difficulty = "nomal";
            customproperties.SEtdifficulty(difficulty);
        }

        else
        {
           
            c = true;
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
               
                for(int i = 0; i < player.Length; i++)
                {
                    if (Getok(i+1))
                    {
                        s++;
                        if (s == playernum)
                        {
                            photonView.RPC(nameof(setdif), RpcTarget.All,difficulty);
                            photonView.RPC(nameof(playermake), RpcTarget.All);
                            PhotonNetwork.CurrentRoom.IsOpen = false;
                        }
                       
                    }
                }
                s = 0;
                
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
            if (difficulty == "nomal") Moneymanager.Money = 1000;
            if (difficulty == "ez") Moneymanager.Money = 1500;
            if (difficulty == "hard") Moneymanager.Money = 0;
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


            Debug.Log(difficulty);

        }

    }
    public void OnpushOK()
    {
       var localplayer = PhotonNetwork.LocalPlayer;
       var localplayernum = localplayer.ActorNumber;
        photonView.RPC(nameof(Setok), RpcTarget.All, localplayernum, true);
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
    public void setdif(string dif)
    {
        difficulty = dif;
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
    [PunRPC]
    void Setok(int number, bool inf)
    {
        switch (number)
        {
            case 1: p1ok = inf; break;
            case 2: p2ok = inf; break;
            case 3: p3ok = inf; break;
            case 4: p4ok = inf; break;
            case 5: p5ok = inf; break;
            case 6: p6ok = inf; break;
            case 7: p7ok = inf; break;
            case 8: p8ok = inf; break;
        }
    }
    

    //numberに取得したいプレイヤーのIDを渡す
    public bool Getok(int number)
    {
        var myinf=false;
        switch (number)
        {
            case 1: myinf = p1ok; break;
            case 2: myinf = p2ok; break;
            case 3: myinf = p3ok; break;
            case 4: myinf = p4ok; break;
            case 5: myinf = p5ok; break;
            case 6: myinf = p6ok; break;
            case 7: myinf = p7ok; break;
            case 8: myinf = p8ok; break;
        }
        return (myinf);
    }
}