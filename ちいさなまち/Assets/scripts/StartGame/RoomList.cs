using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject listButtonPrefab;
    public DataTable rooms = new DataTable();

    void Start(){
        rooms.Columns.Add("RoomName");
        rooms.Columns.Add("NumPeople");
        rooms.Columns.Add("Difficulty");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach (var room in roomList){
            if (room.RemovedFromList){
                DataRow[] removedRoom = rooms.Select($"RoomName = '{room.CustomProperties["RoomName"]}'");
                rooms.Rows.Remove(removedRoom[0]);
            }
            else{
                rooms.Rows.Add(room.CustomProperties["RoomName"], $"{room.PlayerCount.ToString()}/{room.MaxPlayers.ToString()}", room.CustomProperties["Difficulty"]);
            }
        }
        foreach (Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < rooms.Rows.Count; i++){

            //ボタンを生成してcanvasの子にする
            GameObject button = Instantiate(listButtonPrefab, this.transform.position, Quaternion.identity);
            button.transform.SetParent(this.transform, false);

            //ボタンの表示内容を設定
            //このfor文の1回目はルーム名、2回目は参加人数,3回目は難易度
            for (int j = 0; j < 3; j++){
                var buttonsRoomName = button.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                buttonsRoomName.text = rooms.Rows[i][j].ToString();
            }
        }
    }
}
