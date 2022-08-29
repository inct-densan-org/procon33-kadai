using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Namemanager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI namedis;
    private string username;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        username = PhotonNetwork.NickName;
        namedis.text = "NAME   " + username;
    }
}
