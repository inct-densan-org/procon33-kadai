using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gomihotel : MonoBehaviourPunCallbacks
{
    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject = this.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&collision.gameObject.GetPhotonView().OwnerActorNr==PhotonNetwork.LocalPlayer.ActorNumber)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject.SetActive(false);
                Hotelquest.gominum++;
               
            }
        }
    }
}
