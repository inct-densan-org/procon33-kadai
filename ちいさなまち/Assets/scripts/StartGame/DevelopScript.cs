using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DevelopScript : MonoBehaviourPunCallbacks
{


    public void ConnectMaster(){
        if (PhotonNetwork.IsConnected){
            Debug.Log("既にマスターサーバーに接続されています。");
        }else{
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster(){
        Debug.Log("マスターサーバーに接続しました。");
        LobbyJoin();
    }
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log($"接続に失敗したか切断されました。 {cause.ToString()}");
    }


    //ロビー機能は少人数のときは問題ないものの、
    //大規模になると大量の処理と通信が発生する場合がある
    public void LobbyJoin(){
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        Debug.Log("ロビーに参加しました。");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        Debug.Log($"ルームのリストが更新されました。");
        foreach (var room in roomList){
            Debug.Log($"削除済み = {room.RemovedFromList} , {room.ToString()}");
        }
        
    }


    public void LobbyLeave(){
        if (PhotonNetwork.InLobby){
            PhotonNetwork.LeaveLobby();
        }
        else{
            Debug.Log("既にロビーにはいません。");
        }
    }
    public override void OnLeftLobby(){
        Debug.Log("ロビーから退出しました。");
    }


    public void RoomCreate(){
        if (PhotonNetwork.IsConnected){
            //nullか""を渡すと自動でユニークなルーム名が生成されるそう
            PhotonNetwork.CreateRoom(null);
        }
        else{
            Debug.Log("マスターサーバーに接続されていません。");
        }
    }
    public override void OnCreatedRoom(){
        Debug.Log("ルームの作成に成功しました。");
    }
    public override void OnJoinedRoom(){
        Debug.Log("ルームに参加しました。");
        Room currentRoom = PhotonNetwork.CurrentRoom;
        Debug.Log($"ルーム情報:{currentRoom.ToString()}");
    }
    public override void OnCreateRoomFailed(short returnCode, string message){
        
        if (returnCode == 32766){
            Debug.Log($"ルームの作成に失敗しました。 同じ名前のルームが既に存在します。");
        }
        else{
            Debug.Log($"ルームの作成に失敗しました。 {returnCode}:{message}");
        }
    }


    public void RoomLeave(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom(){
        Debug.Log("ルームから退出しました。");
    }

}
