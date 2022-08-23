using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Photon.Pun;
using System;

public class TileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
        Array.Sort(player);
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer) 
        {
            var tilemap = GetComponent<Tilemap>();
            var position = new Vector3Int(0, 0, 0);
            for (int i = 0; i < 27; i++)
            {
                int rnd = UnityEngine.Random.Range(0, 27);
                // タイルの種類を表す配列を用意、一個づつについて座標を割り振る。
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
