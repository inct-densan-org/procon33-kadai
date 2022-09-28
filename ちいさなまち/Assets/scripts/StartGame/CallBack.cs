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
        Debug.Log("接続しました。");
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log($"切断されました。{cause}");
        noticeText.OnDisconnected(cause);
    }


    public override void OnJoinedLobby(){
        Debug.Log("ロビーに接続しました。");
        roomList.ListInit();
    }
    public override void OnLeftLobby(){
        Debug.Log("ロビーから退出しました。");
        roomList.ListInit();
    }

    public override void OnRoomListUpdate(List<RoomInfo> list){
        Debug.Log("リストが更新されました。");
        roomList.OnRoomListUpdate(list);
        if(WindowManager.instance.currentStatus == 1){WindowManager.instance.RoomSelector();}
    }

    //ルーム参加時にシーン移行
    public override void OnJoinedRoom(){
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
