using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomList : MonoBehaviour
{
    public GameObject listButtonPrefab;
    public GameObject optionButtons;
    public GameObject selector;
    public DataTable roomData = new DataTable();
    public DataTable roomList;
    bool[] listOption = new bool[3]; //絞り込みオプション、0から イージー ノーマル ハード
    [System.NonSerialized] public int selectedButtonNum = -1;

    //初期化
    void Start(){
        roomData.Columns.Add("RoomName");
        roomData.Columns.Add("DisplayRoomName");
        roomData.Columns.Add("NumPeople");
        roomData.Columns.Add("Difficulty");

        roomList = roomData.Clone();

        for (int i = 0; i < 3; i++){
            optionButtons.transform.GetChild(i).GetComponent<Toggle>().onValueChanged.AddListener(UpdateRoomList);
        }
    }

    void Update(){
        //なにか部屋が選択されているか
        if (selector.transform.childCount > 0){
            foreach (Transform child in selector.transform){
                if (child.GetComponent<Toggle>().isOn){
                    selectedButtonNum = child.GetSiblingIndex();
                }
            }
        }else{
            selectedButtonNum = -1;
        }

    }

    //ロビー参加時、ロビー退出時にCallBack.csから呼び出される
    public void ListInit(){
        //roomListを初期化
        for (int i = roomList.Rows.Count; i > 0; i--){
            roomList.Rows.RemoveAt(0);
        }
        //roomDataから条件に合う部屋をroomListへ抽出
        for(int i = 0; i < 3; i++){
            if (listOption[i]){
                DataRow[] rooms = roomData.Select($"Difficulty = '{i}'");
                foreach(var room in rooms){
                    roomList.ImportRow(room);
                }
            }
        }
        //表示リストを全削除
        DestroyChild();

    }


    public void UpdateRoomList(bool isOn){
        //isONはaddListenerから受け取るために置かれる、使用されはしない(うまい書き方を知らない)
        for (int i = 0; i < 3; i++){
            listOption[i] = optionButtons.transform.GetChild(i).GetComponent<Toggle>().isOn;
        }
        ListInit();

        for (int i = 0; i < roomList.Rows.Count; i++){

            //ボタンを生成してcanvasの子にする
            GameObject button = Instantiate(listButtonPrefab, this.transform.position, Quaternion.identity);
            button.transform.SetParent(selector.transform, false);
            button.transform.GetComponent<Toggle>().group = transform.GetComponent<ToggleGroup>();

            //ボタンの表示内容を設定
            //このfor文の1回目はルームの表示名、2回目は参加人数,3回目は難易度
            //なおデータテーブルの列は1列目から ルーム名 ルームの表示名 ルームの人数/最大人数(8) 難易度 の4つ
            for (int j = 0; j < 3; j++){
                var buttonsTMP = button.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                string text = roomList.Rows[i][j+1].ToString();
                if (j == 2){
                    if (text == "0"){
                        text = "イージー";
                    }else if (text == "1"){
                        text = "ノーマル";
                    }else if (text == "2"){
                        text = "ハード";
                    }
                }
                buttonsTMP.text = text;
            }
        }
    }

    //ボタンを全削除
    void DestroyChild(){
        foreach (Transform child in selector.transform){
            Destroy(child.gameObject);
        }
    }


    //ルームの情報が更新されたときの処理
    public void OnRoomListUpdate(List<RoomInfo> list){
        foreach (var room in list){
            //この場合ルーム名は表示名ではなく固有のもの
            DataRow[] inListRoom = roomData.Select($"RoomName = '{room.Name}'");
            //削除された部屋の情報か
            if (room.RemovedFromList){
                if (inListRoom.Length > 0){
                    roomData.Rows.Remove(inListRoom[0]);
                }
            }
            else{
                //既存の部屋の情報の場合は以前の情報を削除
                if(inListRoom.Length > 0){
                    roomData.Rows.Remove(inListRoom[0]);
                }
                //部屋に参加可能であるか
                if (room.IsOpen){
                    string difficulty = room.CustomProperties["Difficulty"].ToString();
                    roomData.Rows.Add(room.Name,(room.CustomProperties.ContainsKey("RoomName")) ? room.CustomProperties["RoomName"] : "名称不明" , $"{room.PlayerCount.ToString()}/{room.MaxPlayers.ToString()}", difficulty);
                }
            }
        }

        UpdateRoomList(false);

    }
}
