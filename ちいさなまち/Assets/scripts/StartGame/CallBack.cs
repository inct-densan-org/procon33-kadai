using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CallBack : MonoBehaviourPunCallbacks
{
    public void OnConnectedToMaster(){
        Debug.Log("マスターサーバーに接続しました。");
        PhotonNetwork.JoinLobby();
    }
    public void OnDisconnected(DisconnectCause cause){
        Debug.Log($"接続に失敗したか切断されました。 {cause.ToString()}");
    }


    public void OnJoinedLobby(){
        Debug.Log("ロビーに参加しました。");
    }
    public void OnLeftLobby(){
        Debug.Log("ロビーから退出しました。");
    }
}
