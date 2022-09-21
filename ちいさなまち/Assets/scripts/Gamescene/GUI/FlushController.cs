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
    private static Player player;
    private  Image image;
    public int Player;
    public GameObject GameObject;
    private Infection2@infection ;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        //var tagObjects = GameObject.FindGameObjectsWithTag("Player");
        // var playernum = tagObjects.Length;
        // var playerlist = PhotonNetwork.PlayerList;
        // for(int i = 0; i < playernum; i++)
        // {
        //     if (playerlist[i]==PhotonNetwork.LocalPlayer)Player=i+1;
        // }
        Player = PhotonNetwork.LocalPlayer.ActorNumber;
        image =GameObject. GetComponent<Image>();
        image.color = Color.clear;
        var byou = GetComponent<itibyou>();
      //var  tagObjects = GameObject.FindGameObjectsWithTag("Player");
      //  foreach(var q in tagObjects)
      //  {
      //    var r=  q.GetPhotonView();

      //  }
        if (byou == null)
        {
            byou = gameObject.AddComponent<itibyou>();
        }
        byou.Init(() =>
        {
           // trigger = Customproperties.Getplayerinf(Player);
           //
        });
        byou.Play();
    }

    // Update is called once per frame
    void Update()
    {
        trigger = Infection2.GetPlayerinf(Player);

        Image image = GameObject.GetComponent<Image>();
        image.color = Color.Lerp(Color.clear, target, Mathf.PingPong(Time.time, 1));
        Vector3 pos = GameObject.transform.localPosition;
        if (trigger) pos.z = -5.0f;
        else pos.z = -50.0f;
        GameObject.transform.localPosition = pos;
    }
}