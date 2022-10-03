using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameend : MonoBehaviourPun
{
    private int time,infnum,notinfnum;
    private float water, food;
    private Timekimeru timekimeru;
    private GameObject menumanager;
    public static string reason;
    public static bool iswin;
    private int playernum;
    private Gaugemanager gaugemanager;
    private Infection2 infection2;
    
    private TextMeshProUGUI counttext;
    private bool a;
    // Start is called before the first frame update
    void Start()
    {
        iswin = false;
        infnum = 0;
        notinfnum = 0;
        reason = null;
        menumanager = GameObject.Find("menumaneger");
        timekimeru = menumanager.GetComponent<Timekimeru>();
        gaugemanager = menumanager.GetComponent<Gaugemanager>();
    
    }

    // Update is called once per frame
    void Update()
    {
        var player = PhotonNetwork.PlayerList;
        var p1 = player[0];
     
        water = gaugemanager.watertime;
        food = gaugemanager.foodtime;
        if (water == 100)
        {
            reason = $"{PhotonNetwork.LocalPlayer.NickName}Ç™íEêÖè«èÛÇ≈ê¿Ç¡ÇΩ";
            photonView.RPC(nameof(gameover), RpcTarget.All,reason);
        }
        if (food == 200)
        {
            reason = $"{PhotonNetwork.LocalPlayer.NickName}Ç™âÏéÄÇµÇΩ";
            photonView.RPC(nameof(gameover), RpcTarget.All, reason);
        }
        if (infection2 == null)
        {
            GameObject ds = GameObject.Find("man(Clone)");
            if (ds == null) ds = GameObject.Find("woman(Clone)");
            infection2 = ds.GetComponent<Infection2>();
           
        }
        time = timekimeru.time;
         
        
        if (time == 0&&p1 == PhotonNetwork.LocalPlayer)
        {
            photonView.RPC(nameof(gameEnd), RpcTarget.All);
        }
    }
    [PunRPC]
    public void gameover(string why)
    {
        
        reason = why;
        Debug.Log(why);
        iswin = false;
        PhotonNetwork.LeaveRoom();
    }
    [PunRPC]
    public void gameEnd()
    {
        playernum = PhotonNetwork.PlayerList.Length;
        for (int i = 0; i < playernum; i++)
        {
            bool a = infection2.GetPlayerinf(i);
            if (a == true) infnum++;
            if (a == false) notinfnum++;

        }
        if (infnum >= notinfnum)
        {
            reason = "ä¥êıé“ÇÃÇŸÇ§Ç™ëΩÇ©Ç¡ÇΩ";
            iswin = false;
        }
        else { iswin = true; }
        PhotonNetwork.LeaveRoom();
    }
   
}
