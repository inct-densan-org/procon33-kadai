using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonLogin : MonoBehaviour
{

    private void Start(){
        PhotonNetwork.ConnectUsingSettings();
    }

}
