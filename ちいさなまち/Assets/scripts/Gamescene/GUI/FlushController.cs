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
    private int Player;
    // Start is called before the first frame update
    void Start()
    {
        var a = this.gameObject.GetPhotonView();
        Player = a.OwnerActorNr;

        image = GetComponent<Image>();
        image.color = Color.clear;
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
        
           
            Image image = GetComponent<Image>();
            image.color = Color.Lerp(Color.clear, target, Mathf.PingPong(Time.time, 1));

            bool trigger = Customproperties.Getplayerinf(Player);
       
        Vector3 pos = this.transform.localPosition;

            if (trigger) pos.z = 0.0f;
            else pos.z = -50.0f;

            this.transform.localPosition = pos;
        
       
       
    }
   
}