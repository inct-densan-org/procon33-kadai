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
        Debug.Log("�G������");
        if (collision.gameObject.CompareTag ("Player") )// && cooltime == false)
        {
            Debug.Log("�G������");
            cooltime = true;
            Invoke(nameof(cooldowm), 5f);
            infected = PhotonNetwork.LocalPlayer.GetInfection();
            if ( infected == true)//infected�͓������Ȃ��Ƃ����Ȃ�
            {
                
                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {
                    Debug.Log("���������������");
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
}
