using Photon.Pun;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Animator))]
// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class move : MonoBehaviourPunCallbacks
{
    private bool ispush,ishor,isver,infection;
    private int idX = Animator.StringToHash("x"), idY = Animator.StringToHash("y");
    private Animator animator = null;
    public static Vector3 popo;
    private Vector3 input;
    private new Rigidbody2D rigidbody;
    private float speed=5f;
    private Infection2 Infection2;
    //private void Start()
    //{
    //    this.transform.position = new Vector3(20f, 20f, 0f);
    // }
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GameObject oya = GameObject.Find("Canvas");
       transform.parent = oya.transform;
        transform.localPosition = new Vector3(0,5.7f,-1);
        animator = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        //if (photonView.IsMine)
        //{
        //    var x = Input.GetAxis("Horizontal");
        //    var y = Input.GetAxis("Vertical");
        //    rigidbody.velocity = new Vector3(x, y, 0) * 5;
        //}
           
    }
    private void Update()
    {
        infection = Infection2.infected;
        var x = Input.GetAxisRaw("Horizontal");
      var  y = Input.GetAxisRaw("Vertical");
        if (infection == true)
        {
            speed = 2f;
        }
        else
        {
            speed = 5f;
        }
        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            
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
            transform.Translate(speed * Time.deltaTime * input.normalized);
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

