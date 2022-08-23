using Photon.Pun;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class move : MonoBehaviourPunCallbacks
{
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public static Vector3 popo;
   
    //private void Start()
    //{
    //    this.transform.position = new Vector3(20f, 20f, 0f);
    // }
    public void Start()
    {
       GameObject oya = GameObject.Find("Canvas");
       transform.parent = oya.transform;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {


        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") , 0f);
            transform.Translate(5f * Time.deltaTime * input.normalized);
            popo = transform.position;
            if (x <= 0.1&&0<x){ animator.SetFloat(idX, 0.5f); animator.SetFloat(idY, 0); }
            if (x >= -0.1&&0>x) { animator.SetFloat(idX, -0.5f); animator.SetFloat(idY, 0); }
            if (x > 0.1) { animator.SetFloat(idX, 1); }
            if (x <-0.1) { animator.SetFloat(idX, -1); }
            if (y <= 0.1 && 0 < y) { animator.SetFloat(idY, 0.5f); animator.SetFloat(idX, 0); }
            if (y >= -0.1 && 0 > y) { animator.SetFloat(idY, -0.5f); animator.SetFloat(idX, 0); }
            if (y > 0.1) { animator.SetFloat(idY, 1); }
            if (y < -0.1) { animator.SetFloat(idY, -1); }
        }
    }
   
}

