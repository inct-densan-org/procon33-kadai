using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject listButtonPrefab;

    public DataTable rooms = new DataTable();

    [System.NonSerialized]
    public int selectedButtonNum = -1;

    void Start(){
        rooms.Columns.Add("RoomName");
        rooms.Columns.Add("DisplayRoomName");
        rooms.Columns.Add("NumPeople");
        rooms.Columns.Add("Difficulty");
    }

    void Update(){
        if (gameObject.transform.childCount > 0){
            foreach (Transform child in gameObject.transform){
                if (child.GetComponent<Toggle>().isOn == true){
                    selectedButtonNum = child.GetSiblingIndex();
                }
            }
        }else{
            selectedButtonNum = -1;
        }
    }

    public override void OnJoinedLobby(){
        ListErase();
    }

    void ListErase(){
        for (int i = rooms.Rows.Count; i > 0; i--){
            rooms.Rows.RemoveAt(0);
        }
        DestroyChild();
    }

    void DestroyChild(){
        foreach (Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach (var room in roomList){
            DataRow[] inListRoom = rooms.Select($"RoomName = '{room.Name}'");
            if (room.RemovedFromList){
                rooms.Rows.Remove(inListRoom[0]);
            }
            else{
                if(inListRoom.Length > 0){
                    rooms.Rows.Remove(inListRoom[0]);
                }
                rooms.Rows.Add(room.Name,(room.CustomProperties.ContainsKey("RoomName")) ? room.CustomProperties["RoomName"] : "名称不明" , $"{room.PlayerCount.ToString()}/{room.MaxPlayers.ToString()}", (room.CustomProperties.ContainsKey("Difficulty")) ? room.CustomProperties["Difficulty"] : "難易度不明");
            }
        }

        DestroyChild();

        for (int i = 0; i < rooms.Rows.Count; i++){

            //ボタンを生成してcanvasの子にする
            GameObject button = Instantiate(listButtonPrefab, this.transform.position, Quaternion.identity);
            button.transform.SetParent(this.transform, false);
            button.transform.GetComponent<Toggle>().group = transform.GetComponent<ToggleGroup>();

            //ボタンの表示内容を設定
            //このfor文の1回目はルームの表示名、2回目は参加人数,3回目は難易度
            //なおデータテーブルの列は1列目から ルーム名 ルームの表示名 ルームの人数/最大人数(8) 難易度 の4つ
            for (int j = 0; j < 3; j++){
                var buttonsRoomName = button.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                buttonsRoomName.text = rooms.Rows[i][j+1].ToString();
            }
        }
    }

    public override void OnLeftLobby(){
        ListErase();
    }
}
