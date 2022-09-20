using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NoticeText : MonoBehaviourPunCallbacks
{

    TextMeshProUGUI displayText;


    void Start(){
        displayText = GetComponent<TextMeshProUGUI>();
        if (!PhotonNetwork.InLobby){
            displayText.text = "オンラインに参加しています...";
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        if (roomList.Count == 0){
            displayText.text = "参加できるルームがありません。";
        }else{
            displayText.text = "";
        }
    }

}
