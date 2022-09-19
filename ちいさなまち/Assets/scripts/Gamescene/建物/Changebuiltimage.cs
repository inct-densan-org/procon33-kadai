using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using UnityEngine.UI;

public class Changebuiltimage : MonoBehaviourPunCallbacks
{
    private Image image;
  //  public Sprite naisou, gaisou;
    private bool a;
    public GameObject naisou, gaisou;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
       
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && photonView.IsMine)
    //    {
    //        image.sprite = naisou;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && photonView.IsMine)
    //    {
    //        image.sprite = gaisou;
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
       var a= collision.gameObject.GetPhotonView().OwnerActorNr;
        if (collision.gameObject.CompareTag("Player") && a==PhotonNetwork.LocalPlayer.ActorNumber)
        {
            gaisou.SetActive(true);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        var a = collision.gameObject.GetPhotonView().OwnerActorNr;
        if (collision.gameObject.CompareTag("Player") && a == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            gaisou.SetActive(false);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
