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
    private int f;
   private GameObject[] tagObjects;
    private void Start()
    {

        PhotonNetwork.NickName = "Player";
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"ルームへの参加に失敗しました: {message}");
        
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"ランダムルームへの参加に失敗しました: {message}");
        PhotonNetwork.CreateRoom(null);
    }
    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        b = true;
        localplayer = PhotonNetwork.LocalPlayer;
        var localplayernum = localplayer.ActorNumber;
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
   
    public void OnPhotonPlayerConnected()
    {
        
    }
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
        if (isStart == true&&a==false)
        {
            
            gamestart.SetActive(true);
            wait.SetActive(false);
            a = true;
            clone.SetActive(true);
          
        }
    }
    
    [PunRPC]
    public void IsStart()
    {
        isStart = true;
    }
   
}