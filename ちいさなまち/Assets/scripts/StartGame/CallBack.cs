using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class CallBack : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster(){
        Debug.Log("マスターサーバーに接続しました。");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log($"接続に失敗したか切断されました。 {cause.ToString()}");
    }


    public override void OnJoinedLobby(){
        Debug.Log("ロビーに参加しました。");
        RoomList.instance.ListInit();
    }
    public override void OnLeftLobby(){
        Debug.Log("ロビーから退出しました。");
        RoomList.instance.ListInit();
    }

    public override void OnRoomListUpdate(List<RoomInfo> list){
        Debug.Log("ルームの情報が更新されました。");
        NoticeText.instance.OnRoomListUpdate(list);
        RoomList.instance.OnRoomListUpdate(list);
    }

    //ルーム参加時にシーン移行
    public override void OnJoinedRoom(){
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
