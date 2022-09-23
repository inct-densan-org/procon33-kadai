using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Gameend : MonoBehaviourPun
{
    private int time;
    private Timekimeru timekimeru;
    private GameObject menumanager;
    // Start is called before the first frame update
    void Start()
    {
        menumanager = GameObject.Find("menumaneger");
        timekimeru = menumanager.GetComponent<Timekimeru>();
    }

    // Update is called once per frame
    void Update()
    {
        time = timekimeru.time;
        if (time == 0)
        {
            GameEnd();
        }
    }
    public void GameEnd()
    {
        PhotonNetwork.LeaveRoom();
        
    }
}
