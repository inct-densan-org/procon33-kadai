using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonLogin : MonoBehaviourPunCallbacks
{

    private void Start(){
        PhotonNetwork.ConnectUsingSettings();
    }

}
