using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using Photon.Pun;
using System;

public class TileController : MonoBehaviourPunCallbacks
{
    //public GameObject hospitalPrefab;
    bool[] used = new bool[28];
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        var player = PhotonNetwork.PlayerList;
       
        var p1 = player[0];
        if (p1 == PhotonNetwork.LocalPlayer) 
        {
            for (int i = 0; i < 28; i++) 
            {
                used[i] = false;
            }

            // 病院の場所を決定
            //LargeBuildingDecider(hospitalPrefab);
            // 〇〇の場所を決定
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LargeBuildingDecider(GameObject prefab)
    {
        var position = new Vector3(0, 0, 0);

        var rnd = UnityEngine.Random.Range(0, 8);
        if (rnd == 0 && !used[0])
        {
            position = new Vector3(-12, -12, 0);// 左下
            for (int i = 0; i < 3; i++) used[i] = true;
        }
        else if (rnd == 1 && !used[3]) 
        {
            position = new Vector3(0, -12, 0);  // 下
            for (int i = 3; i < 7; i++) used[i] = true;
        }
        else if (rnd == 2 && !used[7]) 
        {
            position = new Vector3(12, -12, 0); // 右下
            for (int i = 7; i < 10; i++) used[i] = true;
        }
        else if (rnd == 3 && !used[10]) 
        {
            position = new Vector3(12, 0, 0);   // 右
            for (int i = 10; i < 14; i++) used[i] = true;
        }
        else if (rnd == 4 && !used[14]) 
        {
            position = new Vector3(12, 12, 0);  // 右上
            for (int i = 14; i < 17; i++) used[i] = true;
        }
        else if (rnd == 5 && !used[17]) 
        {
            position = new Vector3(0, 12, 0);   // 上
            for (int i = 17; i < 21; i++) used[i] = true;
        }
        else if (rnd == 6 && !used[21]) 
        {
            position = new Vector3(-12, 12, 0); // 左上
            for (int i = 21; i < 24; i++) used[i] = true;
        }
        else if (rnd == 7 && !used[24]) 
        {
            position = new Vector3(-12, 0, 0);  // 左
            for (int i = 24; i < 28; i++) used[i] = true;
        }
        else
        {
            LargeBuildingDecider(prefab);
            return;
        }
        photonView.RPC(nameof(SetLargeBuilding), RpcTarget.AllBufferedViaServer, position, prefab);
    }

    void SetSmallBuilding(GameObject prefab)
    {

    }

    [PunRPC]
    void SetLargeBuilding(Vector3 position, GameObject prefab) 
    {
        // ４マス使う大きな建物のプレハブを設置する
        Instantiate(prefab, position, Quaternion.identity);
    }
    [PunRPC]
    void SetSmallBuildingWithJob(Vector3 position, GameObject prefab)
    {
        // １マスの機能付き建物のプレハブを設置する
        Instantiate(prefab, position, Quaternion.identity);
    }

    [PunRPC]
    void SetSmallBuilding(Vector3Int position, TileBase tileBase)
    {
        tilemap.SetTile(position, tileBase);
    }
}
