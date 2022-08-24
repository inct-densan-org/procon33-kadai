using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime;
    public static bool infected = false;
    private int infectionProbability=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag ("Player") )// && cooltime == false)
        {
            Debug.Log("êGÇ¡ÇΩÇÀ");
            cooltime = true;
            Invoke(nameof(cooldowm), 5f);
            infected = PhotonNetwork.LocalPlayer.GetInfection();
            if ( infected == true)//infectedÇÕìØä˙ÇµÇ»Ç¢Ç∆Ç¢ÇØÇ»Ç¢
            {
                
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Debug.Log("ä¥êıÇµÇøÇ·Ç¡ÇΩÇÀ");
                    infected = true;
                    PhotonNetwork.LocalPlayer.SetInfection(infected);
                }
            }
        }
        
    }
    void cooldowm()
    {
        cooltime = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kansen"))
        {
            infected = true;
            PhotonNetwork.LocalPlayer.SetInfection(infected);
            Debug.Log("ä¥êıÇµÇøÇ·Ç¡ÇΩÇÀ");
        }
    }
}
