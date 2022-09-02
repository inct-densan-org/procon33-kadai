using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PUN2Server : MonoBehaviourPunCallbacks
{
    public static GameObject clone;
    private ItemDataBase itemDataBase;
    private bool man, woman;
    public static int isman;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    public static Player localplayer;
    private FlushController flushController;
    public static bool ii;
    private void Start()
    {
        
        PhotonNetwork.NickName="Player";
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        localplayer = PhotonNetwork.LocalPlayer;
        var localplayernum = localplayer.ActorNumber;
       
        var player = PhotonNetwork.PlayerList;

        ii = true;
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
}