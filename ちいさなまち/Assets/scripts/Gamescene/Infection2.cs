using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Infection2 : MonoBehaviourPunCallbacks
{
    private bool cooltime;
    public static bool infected, haninai;
    private int infectionProbability = 1;
    private CircleCollider2D collider2;
    public GameObject kansenhani;
    public shopmanager shopmanager;
    // Start is called before the first frame update
    void Start()
    {
        //kansenhani = transform.Find("kansenhani").gameObject;
        collider2 = this.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (infected == true)
        {
            collider2.radius = 1f;
        }
        else
        {
            collider2.radius = 0.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))// && cooltime == false)
        {

            cooltime = true;
            Invoke(nameof(cooldowm), 5f);
            infected = PhotonNetwork.LocalPlayer.GetInfection();
            if (infected == true)//infected�͓������Ȃ��Ƃ����Ȃ�
            {

                int rnd = Random.Range(0, 100);
                if (rnd <= infectionProbability)
                {

                    infected = true;
                    PhotonNetwork.LocalPlayer.SetInfection(infected);
                }
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shop"))
        {
            haninai = true;
        }
        else
        {
            haninai = false;
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

        }
    }
}
