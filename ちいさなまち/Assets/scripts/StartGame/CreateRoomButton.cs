using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateRoomButton : MonoBehaviourPunCallbacks
{
    public GameObject difficultyButtons;
    public TextMeshProUGUI inputField;
    string roomName;

    void Update(){
        roomName = inputField.text.Replace("\u200b", "");

        if (!System.String.IsNullOrWhiteSpace(roomName)){
            GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 1f);
        }else{
            GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 0.75f);
        }
    }


    public void OnClick(){
        if (System.String.IsNullOrWhiteSpace(roomName)){
            roomName = "ルーム";
        }else{
            roomName = roomName.Replace(" ", "_");
            roomName = roomName.Replace("　", "_");
        }

        string difficulty;
        if (difficultyButtons.transform.GetChild(0).GetComponent<Toggle>().isOn == true){
            difficulty = "0";
        }else if(difficultyButtons.transform.GetChild(1).GetComponent<Toggle>().isOn == true){
            difficulty = "1";
        }else{
            difficulty = "2";
        }

            //カスタムプロパティを設定 後でユーザーが入力できるように変更
            var customProperties = new Hashtable();
            customProperties["RoomName"] = roomName;
            customProperties["Difficulty"] = difficulty;

            //ルームの設定
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 8;
            roomOptions.CustomRoomProperties =customProperties;
            roomOptions.CustomRoomPropertiesForLobby = new[] {"RoomName", "Difficulty"};

            PhotonNetwork.CreateRoom(null, roomOptions);
    }
}
