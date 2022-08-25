using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PUN2Server : MonoBehaviourPunCallbacks
{

    public static GameObject clone;

    private bool man, woman;
    private void Start()
    {

        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        int isman = Random.Range(0, 2);
        if (isman == 0)
        {
            clone = PhotonNetwork.Instantiate("man", new Vector3(20, 15, -1), Quaternion.identity);
        }
        if (isman == 1)
        {
            clone = PhotonNetwork.Instantiate("woman", new Vector3(20, 15, -1), Quaternion.identity);
        }



    }

}