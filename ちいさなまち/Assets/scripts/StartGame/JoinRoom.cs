using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public RoomList roomList;
    
    void Update(){
        //Debug.Log(roomList.selectedButtonNum);
        if (roomList.selectedButtonNum > -1){
            GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 1f);
        }else{
            GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 0.75f);
        }
    }

    void RoomJoin(){
        string roomName = roomList.rooms.Rows[roomList.selectedButtonNum][0].ToString();
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnJoinedRoom(){
        SceneManager.LoadScene("GameScene");
    }
}
