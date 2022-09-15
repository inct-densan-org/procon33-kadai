using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using UnityEngine.UI;

public class Changebuiltimage : MonoBehaviourPunCallbacks
{
    private Image image;
    public Sprite naisou, gaisou;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && photonView.IsMine)
        {
            image.sprite = gaisou;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && photonView.IsMine)
        {
            image.sprite = naisou;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
