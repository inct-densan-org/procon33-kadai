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
   
    // Start is called before the first frame update
    void Start()
    {
        
         image = GetComponent<Image>();
        image.color = Color.clear;
        player= PhotonNetwork.LocalPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        var ii = PUN2Server.ii;
        if (ii == true)
        {
           
            Image image = GetComponent<Image>();
            image.color = Color.Lerp(Color.clear, target, Mathf.PingPong(Time.time, 1));

            bool trigger = Customproperties.Getplayerinf(player.ActorNumber);

            Vector3 pos = this.transform.position;

            if (trigger) pos.z = 0.0f;
            else pos.z = -50.0f;

            this.transform.position = pos;
        }
       
       
    }
   
}