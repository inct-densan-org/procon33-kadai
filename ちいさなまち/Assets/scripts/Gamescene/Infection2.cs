using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime, infected=false;

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
            Debug.Log("触ったね");
            cooltime = true;
            Invoke(nameof(cooldowm), 5f);
            infected = PhotonNetwork.LocalPlayer.GetInfection();
            if ( infected == true)//infectedは同期しないといけない
            {
                
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Debug.Log("感染しちゃったね");
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
            Debug.Log("感染しちゃったね");
        }
    }
}
