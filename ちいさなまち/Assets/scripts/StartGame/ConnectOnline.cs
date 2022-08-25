using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectOnline : MonoBehaviour
{
    public void OnClick(){
        PhotonNetwork.ConnectUsingSettings();
    }

    void OnConnectedToMaster(){

    }
}
