using Photon.Pun;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class move : MonoBehaviourPunCallbacks
{
    private bool ispush,ishor,isver;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public static Vector3 popo;
    private Vector3 input;
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
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            if (Input.GetAxisRaw("Horizontal") != 0&&isver==false )
            {
                input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0f);ishor = true;
            }
            else if(Input.GetAxisRaw("Vertical") != 0 && ishor == false)
                {
                input = new Vector3(0, Input.GetAxisRaw("Vertical"), 0f);isver = true;
            }
            else
            {
                input = new Vector3(0, 0, 0f);
            }
            transform.Translate(5f * Time.deltaTime * input.normalized);
            popo = transform.position;
            if (Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.RightArrow)){ animator.SetFloat(idX, 0.5f); animator.SetFloat(idY, 0); ispush = false; ishor = false; }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { animator.SetFloat(idX, -0.5f); animator.SetFloat(idY, 0); ispush=false; ishor = false; }
            if (x > 0.1 && ispush == false) { animator.SetFloat(idX, 1); ispush = true; }
            if (x <-0.1 && ispush == false) { animator.SetFloat(idX, -1); ispush = true; }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { animator.SetFloat(idY, 0.5f); animator.SetFloat(idX, 0); ispush = false; isver = false;  }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { animator.SetFloat(idY, -0.5f); animator.SetFloat(idX, 0); ispush = false;isver = false; }
            if (y > 0.1 && ispush == false) { animator.SetFloat(idY, 1); ispush = true; }
            if (y < -0.1 && ispush == false) { animator.SetFloat(idY, -1); ispush = true; }
        }
    }
   
}

