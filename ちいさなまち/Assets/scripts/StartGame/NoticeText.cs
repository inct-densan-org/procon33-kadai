using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NoticeText : MonoBehaviour
{

    TextMeshProUGUI displayText;
    public static NoticeText instance;

    void Awake(){
        if(instance is null){
            instance = this;
        }

    }
    void Start(){
        displayText = GetComponent<TextMeshProUGUI>();
        if (!PhotonNetwork.InLobby){
            displayText.text = "オンラインに参加しています...";
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinLobby();
        }
    }

    //CallBack.csから呼び出される
    public void OnRoomListUpdate(List<RoomInfo> roomList){
        if (roomList.Count == 0){
            displayText.text = "参加できるルームがありません。";
        }else{
            Debug.Log("ルームあり");
            displayText.text = "";
        }
    }

}
