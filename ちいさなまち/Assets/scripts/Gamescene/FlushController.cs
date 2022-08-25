using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class FlushController : MonoBehaviourPunCallbacks
{
    Color target = new Color(0.5f, 0f, 0f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();
        image.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        Image image = GetComponent<Image>();
        image.color = Color.Lerp(Color.clear, target, Mathf.PingPong(Time.time, 1));

        bool trigger = PhotonNetwork.LocalPlayer.GetInfection();

        Vector3 pos = this.transform.position;

        if (trigger) pos.z = 0.0f;
        else pos.z = -50.0f;
    }
}
