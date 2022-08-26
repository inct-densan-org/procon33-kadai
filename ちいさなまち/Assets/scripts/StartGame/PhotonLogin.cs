using UnityEngine;
using Photon.Pun;

public class PhotonLogin : MonoBehaviour
{

    void OnEnable(){
        if (!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }

}
