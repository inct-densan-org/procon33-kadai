using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class CallBack : MonoBehaviourPunCallbacks
{
    public RoomList roomList;
    public NoticeText noticeText;

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause){
    }


    public override void OnJoinedLobby(){
        roomList.ListInit();
    }
    public override void OnLeftLobby(){
        roomList.ListInit();
    }

    public override void OnRoomListUpdate(List<RoomInfo> list){
        roomList.OnRoomListUpdate(list);
        noticeText.CheckRoomList();
    }

    //ルーム参加時にシーン移行
    public override void OnJoinedRoom(){
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
