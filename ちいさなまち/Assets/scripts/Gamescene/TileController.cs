using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Photon.Pun;
using System;

public class TileController : MonoBehaviourPunCallbacks
{
    public GameObject hospitalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        Array.Sort(player);
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer) 
        {
            var tilemap = GetComponent<Tilemap>();
            var position = new Vector3(0, 0, 0);
            // 病院の場所を決定
            var rnd = UnityEngine.Random.Range(0, 8);
            if (rnd == 0) position = new Vector3(-12, -12, 0);     // 左下
            else if (rnd == 1) position = new Vector3(0, -12, 0);  // 下
            else if (rnd == 2) position = new Vector3(12, -12, 0); // 右下
            else if (rnd == 3) position = new Vector3(12, 0, 0);   // 右
            else if (rnd == 4) position = new Vector3(12, 12, 0);  // 右上
            else if (rnd == 5) position = new Vector3(0, 12, 0);   // 上
            else if (rnd == 6) position = new Vector3(-12, 12, 0); // 左上
            else if (rnd == 7) position = new Vector3(-12, 0, 0);  // 左

            photonView.RPC(nameof(SetHospital), RpcTarget.AllBufferedViaServer, position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void SetHospital(Vector3 position)
    {
        Instantiate(hospitalPrefab, position, Quaternion.identity);
    }
}
