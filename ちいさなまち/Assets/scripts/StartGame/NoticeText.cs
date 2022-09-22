using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NoticeText : MonoBehaviour
{

    TextMeshProUGUI displayText;
    public RoomList roomList;

    void OnEnable(){
        displayText = GetComponent<TextMeshProUGUI>();
        CheckRoomList();
    }

    //CallBack.csから呼び出される
    public void CheckRoomList(){
        displayText = GetComponent<TextMeshProUGUI>();
        if (gameObject.activeInHierarchy){
            if (!PhotonNetwork.InLobby){
                displayText.text = "オンラインに参加しています...";
                if(!PhotonNetwork.IsConnected){
                    PhotonNetwork.ConnectUsingSettings();
                }
                PhotonNetwork.JoinLobby();
            }
            else if (roomList.roomList.Rows.Count > 0){
                displayText.text = "";
            }else{
                displayText.text = "参加できるルームがありません。";
            }
        }
    }

    //CallBack.csから呼び出し
    public void OnDisconnected(DisconnectCause cause){
        displayText = GetComponent<TextMeshProUGUI>();
        displayText.text = $"オンラインに参加できませんでした。\nインターネットに接続されているかご確認ください。\n({cause})";
    }
}
