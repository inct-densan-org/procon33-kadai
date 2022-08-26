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
        displayText = this.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        if (!PhotonNetwork.InLobby){
            if (PhotonNetwork.IsConnected){
            displayText.text = "ロビーに参加しています...";
            }
            else{
                displayText.text = "オンラインに参加しています...";
            }
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
