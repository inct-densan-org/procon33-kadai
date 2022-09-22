using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonLogin : MonoBehaviour
{

    public void Start(){
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }

}
