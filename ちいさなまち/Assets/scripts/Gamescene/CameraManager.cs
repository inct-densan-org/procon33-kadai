using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;  // Cinemachine��ǉ���using
using Photon.Pun;
public class CameraManager : MonoBehaviourPunCallbacks
{
    public Vector3 targetpo = Move.popo;
    Vector3 offset;
    private CinemachineVirtualCamera _virtualCamera;
    // Update is called once per frame
    void Update()
    {
        //if (photonView.IsMine)
        //{
            targetpo = Move.popo;
            
            offset = new Vector3(0, 0, -10);
            transform.position = targetpo + offset;
        //}
    }
}
