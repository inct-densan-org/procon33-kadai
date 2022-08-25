using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;  // Cinemachine��ǉ���using

public class camera : MonoBehaviourPunCallbacks
{
    public Vector3 targetpo = move.popo;
    Vector3 offset;
    private CinemachineVirtualCamera _virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (photonView.IsMine)
        //{
            targetpo = move.popo;
            
            offset = new Vector3(0, 0, -10);
            transform.position = targetpo + offset;
        //}
    }
}
