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
        if (!PhotonNetwork.InLobby){
            displayText.text = "オンラインに参加しています...";
            if(!PhotonNetwork.IsConnected){
                PhotonNetwork.ConnectUsingSettings();
            }
            PhotonNetwork.JoinLobby();
        }
        CheckRoomList();
    }

    //CallBack.csから呼び出される
    public void CheckRoomList(){
        if (gameObject.activeInHierarchy){
            if (roomList.roomList.Rows.Count > 0){
                displayText.text = "";
            }else{
                displayText.text = "参加できるルームがありません。";
            }
        }
    }

}
