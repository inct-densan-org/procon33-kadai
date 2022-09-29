using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class FlushController : MonoBehaviourPunCallbacks
{
    private static Color target = new Color(0.5f, 0f, 0f, 0.5f);
    private Move move;
    public static ExitGames.Client.Photon.Hashtable roomHash;
    private PUN2Server pUN2Server;
    private Player player;
    private  Image image;
    public int Player;
    public GameObject GameObject;
    public Infection2 infection2 ;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        
        Player = PhotonNetwork.LocalPlayer.ActorNumber;
        image =GameObject. GetComponent<Image>();
        image.color = Color.clear;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (infection2 == null)
        {
            GameObject ds = GameObject.Find("man(Clone)");
            if (ds == null) ds = GameObject.Find("woman(Clone)");
            infection2 = ds.GetComponent<Infection2>();
            
        }
        trigger = infection2.GetPlayerinfeffect(Player);

        Image image = GameObject.GetComponent<Image>();
        image.color = Color.Lerp(Color.clear, target, Mathf.PingPong(Time.time, 1));
        Vector3 pos = GameObject.transform.localPosition;
        if (trigger) GameObject.SetActive(true);
        else GameObject.SetActive(false);
        GameObject.transform.localPosition = pos;
    }
}